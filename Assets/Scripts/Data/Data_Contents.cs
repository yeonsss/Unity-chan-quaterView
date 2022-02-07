using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �̰��� ������ �����͸� �ҷ��ö� ������ ���˰� �Ȱ��� �ۼ�

#region Stat
[Serializable]
public class Stat
{
    //���� ������ private�� �ϰ������ ��� �ؾ��ұ� public���� �ϸ� ������ �ȵǴµ�...
    // [serializedField]�� �������ָ� �ȴ�.
    public int level;
    public int hp;
    public int attack;
    // json �̸��� ���� ������ ����
    // �ڷ����� ������� �Ѵ�.

}

// �ø���������� => �޸𸮿� ����ִ� �����͸� ���Ϸ� ��ȯ�� �� �ִٴ� �ǹ�
[Serializable]
public class StatData : ILoader<int, Stat>
{
    public List<Stat> stats = new List<Stat>();

    public Dictionary<int, Stat> MakeDict()
    {
        Dictionary<int, Stat> dict = new Dictionary<int, Stat>();
        foreach (Stat stat in stats)
        {
            dict.Add(stat.level, stat);
        }
        return dict;
    }
}

#endregion

