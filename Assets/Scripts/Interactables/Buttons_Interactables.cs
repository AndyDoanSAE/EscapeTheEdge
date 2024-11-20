using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons_Interactables : Interactables
{
    protected override void Selected()
    {
        if (isActive)
        {
            outline.enabled = false;
            render.material.SetColor("_BaseColor", Color.green);
        }
        else
            outline.enabled = isSelected;
    }
}
