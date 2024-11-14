using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour
{
    public bool isSelected;
    public bool canOpen;
    private Outline outline;

    protected void Awake()
    {
        outline = GetComponent<Outline>();
    }

    // Start is called before the first frame update
    protected virtual void Start()
    {
        outline.enabled = false;
        isSelected = false;
        canOpen = false;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        Selection();
    }

    public virtual void Activation()
    {
        canOpen = true;
    }

    private void Selection()
    {
        outline.enabled = isSelected;
    }
}
