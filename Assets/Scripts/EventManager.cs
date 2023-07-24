using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public delegate void MagicDone();
    public static MagicDone magicOver;

    public static void PlayerMagicDone()
    {
        magicOver?.Invoke();
    }

}
