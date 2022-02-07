using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Define : MonoBehaviour
{

    public enum UIEvent
    {
        Click,
        Drag,

    }

    public enum Sound
    {
        Bgm,
        Effect,
        MaxCount,
    }
    public enum MouseEvent
    {
        Press,
        Click,
    }
    public enum CameraMode
    {
        QuarterView,
    }

    public const int Max_Inventory_Volume = 10;

    public enum Scene
    {
        Unknown,
        Login,
        Lobby,
        Game,
    }
}
