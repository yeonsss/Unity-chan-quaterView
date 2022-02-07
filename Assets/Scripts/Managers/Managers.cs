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

    DataManager _data = new DataManager();
    InputManager _input = new InputManager();
    PoolManager _pool = new PoolManager();
    ResourceManager _resource = new ResourceManager();
    SceneManagerEx _scene = new SceneManagerEx();
    SoundManager _sound = new SoundManager();
    UIManager _ui = new UIManager();

    public static DataManager Data { get { return Instance._data; } }
    public static InputManager Input { get { return Instance._input; } }
    public static PoolManager Pool { get { return Instance._pool; } }
    public static ResourceManager Resource { get { return Instance._resource; } }
    public static SceneManagerEx Scene { get { return Instance._scene; } }
    public static SoundManager Sound { get { return Instance._sound; } }
    public static UIManager UI { get { return Instance._ui; } }

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
            // Instance�ȿ� �� Instance�� ȣ������ ���� => ���ѷ���
            s_Instance._data.Init();
            s_Instance._sound.Init();
            s_Instance._pool.Init();
        }
    }
    // �� �̵��� ������� �ϴ� ģ���� ����
    public static void Clear()
    {
        Sound.Clear();
        Input.Clear();
        UI.Clear();
        Scene.Clear();

        Pool.Clear();
    }
}
