using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;

public class UI_Button : UI_Base
{

    // enum을 사용해서 UI 자동화
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
    

    // 이름을 통해 해당 컴포넌트들 찾아서 하나로 묶어주는 함수
    

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
    //반드시 public으로 할 것.
    public void OnButtonClicked(PointerEventData data)
    {
        _score++;
        Get<Text>((int)Texts.ScoreText).text = $"점수 : {_score}";
    }

}
