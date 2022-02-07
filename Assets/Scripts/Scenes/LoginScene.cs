using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoginScene : BaseScene
{
    protected override void Init()
    {
        base.Init();

        SceneType = Define.Scene.Login;

        //List<GameObject> list = new List<GameObject>();

        //for(int i = 0; i < 10; i++)
        //{
        //    list.Add(Managers.Resource.Instantiate("UnityChan"));
        //}

        //foreach(GameObject obj in list)
        //{
        //    Managers.Resource.Destory(obj);
        //    // ��Ʈ���� �Ҷ����� Ǯ��������Ʈ�� ������ Ǯ���� ���Եȴ�. ����� �������...
        //}
    }

    public override void Clear()
    {
        Debug.Log("LoginScene Clear!");
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            Managers.Scene.LoadScene(Define.Scene.Game);
            // �񵿱� ó���� �ϱ� ���� �Լ�
            // �Ѿ���� ���� �ε��ؾ��Ұ� ���� ���ٸ� �ε�ȭ���� ���� ��ٸ��°͵� ������
            // �α��� ȭ�鿡������ �ε带 �����ϴ� ����� �ִ�.
            // �Ʒ��� �Լ��� ����Ѵٸ� �α���â�� ������ ���ÿ� ���������� ���Ӿ� �ε��� �����ϴ�.
            //SceneManager.LoadSceneAsync();

        }
    }

    
}
