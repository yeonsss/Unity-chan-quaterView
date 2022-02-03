using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : MonoBehaviour
{
    // Start is called before the first frame update
    //디버깅 모드 중에는 유니티로 안돌아가짐

    // 매니저 => 게임 관리자 역활 (GM)
    
    // static으로 구현

    static Managers s_Instance; // 유일성이 보장된다.
    static Managers Instance { get { Init();  return s_Instance; }   }
    // 유일한 매니저를 갖고 있다.

    InputManager _input = new InputManager();
    ResourceManager _resource = new ResourceManager();
    public static InputManager Input { get { return Instance._input; } }
    public static ResourceManager Resource { get { return Instance._resource; } }

    void Start()
    {
        // 게임 매니저처럼 특정 인스턴스가 하나만 존재할때 싱글톤 사용
        //초기화
        //GameObject go = GameObject.Find("@Managers");
        //Instance = go.GetComponent<Managers>();

        // 아무리 매니저를 복사해서 Start()하더라도
        // 결국 Instance = (매니저 원본) 만 호출됨.

        // 만약 매니저스가 유니티에 없다면?
        // instance는 null로 에러난다. 때문에 위의 코드보단
        // 초기화를 아예 따로 만든다.
        Init();    }

    // Update is called once per frame
    void Update()
    {
        // 이벤트가 있는지 계속 검사 
        // 이벤트는 종류마다 추가해줘야 한다.
        _input.OnUpdate(); //입력 이벤트
    }

    static void Init()
    {
        if (s_Instance == null)
        {
            GameObject go = GameObject.Find("@Managers");
            if (go == null)
            {
                go = new GameObject { name = "@Managers" };
                go.AddComponent<Managers>();
            }

            DontDestroyOnLoad(go);
            s_Instance = go.GetComponent<Managers>();
        }    }
}
