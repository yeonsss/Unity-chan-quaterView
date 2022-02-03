using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : MonoBehaviour
{
    // Start is called before the first frame update
    //����� ��� �߿��� ����Ƽ�� �ȵ��ư���

    // �Ŵ��� => ���� ������ ��Ȱ (GM)
    
    // static���� ����

    static Managers s_Instance; // ���ϼ��� ����ȴ�.
    static Managers Instance { get { Init();  return s_Instance; }   }
    // ������ �Ŵ����� ���� �ִ�.

    InputManager _input = new InputManager();
    ResourceManager _resource = new ResourceManager();
    public static InputManager Input { get { return Instance._input; } }
    public static ResourceManager Resource { get { return Instance._resource; } }

    void Start()
    {
        // ���� �Ŵ���ó�� Ư�� �ν��Ͻ��� �ϳ��� �����Ҷ� �̱��� ���
        //�ʱ�ȭ
        //GameObject go = GameObject.Find("@Managers");
        //Instance = go.GetComponent<Managers>();

        // �ƹ��� �Ŵ����� �����ؼ� Start()�ϴ���
        // �ᱹ Instance = (�Ŵ��� ����) �� ȣ���.

        // ���� �Ŵ������� ����Ƽ�� ���ٸ�?
        // instance�� null�� ��������. ������ ���� �ڵ庸��
        // �ʱ�ȭ�� �ƿ� ���� �����.
        Init();    }

    // Update is called once per frame
    void Update()
    {
        // �̺�Ʈ�� �ִ��� ��� �˻� 
        // �̺�Ʈ�� �������� �߰������ �Ѵ�.
        _input.OnUpdate(); //�Է� �̺�Ʈ
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
