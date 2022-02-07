using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene : BaseScene
{
    // 만약 하이라키에 gameScene이 들어가 있는 @Scene이 없다면
    // 이런 Start에 init()이 들어있기 때문에 함수가 동작을 하지 않는다.
    // @scene을 굳이 안만들고 혼자서 실행되는 함수를 만들려면 아래함수를 이용할 것.
    // 이걸 부모 클래스에 부착시킨다면?
    // 자식의 Init()까지 동작하기 때문에 편리하게 사용할 수 있다.
    //private void Awake() => start보다 먼저 동작.
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
