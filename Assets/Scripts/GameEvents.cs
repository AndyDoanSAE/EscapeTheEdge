using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameEvents
{
    public delegate void VoidDelegate();

    public static VoidDelegate HasKey;

    public static void ObtainedKey()
    {
        HasKey?.Invoke();
    }
}