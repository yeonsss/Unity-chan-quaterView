using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;

public class UI_Button : UI_Base
{

    // enum�� ����ؼ� UI �ڵ�ȭ
    enum Buttons
    {
        PointButton,
    }

    enum Texts
    {
        PointText,
        ScoreText,
    }

    enum GameObjects
    {
        TestObject,
    }
    enum Images
    {
        ItemIcon,
    }
    

    // �̸��� ���� �ش� ������Ʈ�� ã�Ƽ� �ϳ��� �����ִ� �Լ�
    

    private void Start()
    {
        Bind<Button>(typeof(Buttons));
        Bind<Text>(typeof(Texts));
        Bind<GameObject>(typeof(GameObjects));
        Bind<Image>(typeof(Images));

        

        GetButton((int)Buttons.PointButton).gameObject.AddUIEvent(OnButtonClicked);

        GameObject go = GetImage((int)Images.ItemIcon).gameObject;
        AddUIEvent(go, (PointerEventData data) => { go.gameObject.transform.position = data.position; }, Define.UIEvent.Drag);
    }

    int _score = 0;
    //�ݵ�� public���� �� ��.
    public void OnButtonClicked(PointerEventData data)
    {
        _score++;
        Get<Text>((int)Texts.ScoreText).text = $"���� : {_score}";
    }

}
