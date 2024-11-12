using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactables : MonoBehaviour
{   
    // [SerializeField] private string cameraTag;

    public bool isActive;
    public bool isSelected;
    
    // private Renderer itemRender;
    private Outline outline;

    private void Awake()
    {
        isActive = false;
        isSelected = false;
        
        outline = gameObject.AddComponent<Outline>();
        outline.enabled = false;
    }

    // Start is called before the first frame update
    private void Start()
    {
        // itemRender = GetComponent<Renderer>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (isActive)
        {
            outline.enabled = false;
        }
        else if (isSelected)
        {
            outline.enabled = true;
            outline.OutlineMode = Outline.Mode.OutlineAll;
        }
        else
            outline.enabled = false;
    }
}
