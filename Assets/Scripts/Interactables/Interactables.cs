using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactables : MonoBehaviour
{   
    public bool isActive;
    public bool isSelected;
    
    protected Renderer render;
    protected Outline outline;

    protected virtual void Awake()
    {
        isActive = false;
        isSelected = false;
        
        outline = gameObject.AddComponent<Outline>();
        outline.enabled = false;
        
        render = GetComponent<Renderer>();
    }

    // Start is called before the first frame update
    protected virtual void Start()
    {
        
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        Selected();
    }

    protected virtual void Selected()
    {
        outline.enabled = isSelected;
    }
}
