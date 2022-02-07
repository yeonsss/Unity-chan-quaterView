using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Inven : UI_Scene
{
    enum GameObjects
    {
        GridPanel,
    }

    

    void Start()
    {
        Init();
    }

    public override void Init()
    {
        base.Init();

        Bind<GameObject>(typeof(GameObjects));

        GameObject gridPanel = Get<GameObject>((int)GameObjects.GridPanel);
        foreach(Transform child in gridPanel.transform)
        {
            Managers.Resource.Destory(child.gameObject);
        }

        // ���� �κ��丮 ������ �����ؼ� ĭ�� ������ �Ѵ�.
        for (int i = 0; i < Define.Max_Inventory_Volume; i++)
        {
            GameObject item = Managers.UI.makeSubItem<UI_Inven_Item>(gridPanel.transform).gameObject;

            UI_Inven_Item invenItem = item.GetOrAddComponent<UI_Inven_Item>();
            invenItem.SetInfo($"�����{i}��");
        }
    }
}
