using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene : BaseScene
{
    // ���� ���̶�Ű�� gameScene�� �� �ִ� @Scene�� ���ٸ�
    // �̷� Start�� init()�� ����ֱ� ������ �Լ��� ������ ���� �ʴ´�.
    // @scene�� ���� �ȸ���� ȥ�ڼ� ����Ǵ� �Լ��� ������� �Ʒ��Լ��� �̿��� ��.
    // �̰� �θ� Ŭ������ ������Ų�ٸ�?
    // �ڽ��� Init()���� �����ϱ� ������ ���ϰ� ����� �� �ִ�.
    //private void Awake() => start���� ���� ����.
    //{
    //  Init();
    //}
    Coroutine co;

    protected override void Init()
    {
        base.Init();
        SceneType = Define.Scene.Game;
        Managers.UI.ShowSceneUI<UI_Inven>();

        Dictionary<int, Stat> dict = Managers.Data.StatDict;

        //co = StartCoroutine("ExplodeAfterSeconds", 4.0f);
        //StartCoroutine("CoStopExplode", 2.0f);
    }

    //IEnumerator CoStopExplode(float seconds)
    //{
    //    Debug.Log("Expolde Enter");
    //    yield return new WaitForSeconds(seconds);
    //    Debug.Log("stop");
    //    if (co != null)
    //    {
    //        StopCoroutine(co);
    //        co = null;
    //    }
    //}

    //IEnumerator ExplodeAfterSeconds(float seconds)
    //{
    //    Debug.Log("Expolde Enter");
    //    yield return new WaitForSeconds(seconds);
    //    Debug.Log("bbang");
    //    co = null;
    //}

    public override void Clear()
    {

    }
}
