using System.Collections.Generic;
using UnityEngine;



public interface ILoader<Key, Value>
{
    Dictionary<Key, Value> MakeDict();
}

public class DataManager
{
    // 이친구는 거의 항상 있어야 하기 때문에 clear를 만들지 않겠다.
    // json => 구조체 : {}, 배열 : []

    public Dictionary<int, Stat> StatDict { get; private set; } = new Dictionary<int, Stat>();

    public void Init()
    {
        StatDict = LoadJson<StatData, int, Stat>("StatData").MakeDict();
    }

    Loader LoadJson<Loader, Key, Value>(string path) where Loader : ILoader<Key, Value>
    {
        TextAsset textAsset = Managers.Resource.Load<TextAsset>($"Data/{path}");

        // tojson => 메모리에 있는 데이터를 json파일로 변환하는 함수
        // fromjson => json형태의 파일을 메모리에 있는 클래스에 입력하는 함수
        return JsonUtility.FromJson<Loader>(textAsset.text);
    }
}
