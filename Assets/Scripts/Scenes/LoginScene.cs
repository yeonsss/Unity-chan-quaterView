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
        //    // 디스트로이 할때마다 풀어블오브젝트는 무조건 풀링에 들어가게된다. 몇마리든 상관없이...
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
            // 비동기 처리를 하기 위한 함수
            // 넘어가려는 씬이 로드해야할게 무지 많다면 로딩화면을 만들어서 기다리는것도 있지만
            // 로그인 화면에서부터 로드를 시작하는 방법도 있다.
            // 아래의 함수를 사용한다면 로그인창이 떠짐과 동시에 병렬적으로 게임씬 로딩이 가능하다.
            //SceneManager.LoadSceneAsync();

        }
    }

    
}
