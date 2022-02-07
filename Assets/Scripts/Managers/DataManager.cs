using System.Collections.Generic;
using UnityEngine;



public interface ILoader<Key, Value>
{
    Dictionary<Key, Value> MakeDict();
}

public class DataManager
{
    // ��ģ���� ���� �׻� �־�� �ϱ� ������ clear�� ������ �ʰڴ�.
    // json => ����ü : {}, �迭 : []

    public Dictionary<int, Stat> StatDict { get; private set; } = new Dictionary<int, Stat>();

    public void Init()
    {
        StatDict = LoadJson<StatData, int, Stat>("StatData").MakeDict();
    }

    Loader LoadJson<Loader, Key, Value>(string path) where Loader : ILoader<Key, Value>
    {
        TextAsset textAsset = Managers.Resource.Load<TextAsset>($"Data/{path}");

        // tojson => �޸𸮿� �ִ� �����͸� json���Ϸ� ��ȯ�ϴ� �Լ�
        // fromjson => json������ ������ �޸𸮿� �ִ� Ŭ������ �Է��ϴ� �Լ�
        return JsonUtility.FromJson<Loader>(textAsset.text);
    }
}
