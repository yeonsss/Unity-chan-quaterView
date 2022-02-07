using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 이곳은 파일의 데이터를 불러올때 데이터 포맷과 똑같이 작성

#region Stat
[Serializable]
public class Stat
{
    //만약 이쪽을 private로 하고싶은데 어떻게 해야할까 public으로 하면 설정이 안되는데...
    // [serializedField]를 설정해주면 된다.
    public int level;
    public int hp;
    public int attack;
    // json 이름과 같은 변수명 설정
    // 자료형도 맞춰줘야 한다.

}

// 시리얼라이즈어블 => 메모리에 들고있는 데이터를 파일로 변환할 수 있다는 의미
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

