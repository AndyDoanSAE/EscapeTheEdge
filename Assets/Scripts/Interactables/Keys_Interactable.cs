using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keys_Interactable : Interactables
{
    public string keyID;

    public void Despawn()
    {
        Destroy(gameObject);
    }
}
