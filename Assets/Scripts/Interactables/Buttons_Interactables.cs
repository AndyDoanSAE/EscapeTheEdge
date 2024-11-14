using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons_Interactables : Interactables
{
    protected override void Awake()
    {
        base.Awake();
    }

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }

    protected override void Selected()
    {
        if (isActive)
        {
            outline.enabled = false;
            render.material.SetColor("_BaseColor", Color.green);
        }
        // else if (isSelected)
        //     outline.enabled = true;
        else
            outline.enabled = isSelected;
    }
}
