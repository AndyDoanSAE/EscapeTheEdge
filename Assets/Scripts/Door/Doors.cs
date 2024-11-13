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
        outline.enabled = false;
        isSelected = false;
        canOpen = false;
    }

    // Start is called before the first frame update
    protected virtual void Start()
    {

    }

    // Update is called once per frame
    protected virtual void Update()
    {
        Selection();
    }

    public virtual void Activation()
    {
        
    }

    private void Selection()
    {
        outline.enabled = isSelected;
    }
}
