using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactables : MonoBehaviour
{   
    [SerializeField] private PlayerCamera player;

    [SerializeField] private string cameraTag;

    public bool isActive;
    public bool isSelected;

    public Vector3 destination;

    private Renderer itemRender;

    private void Awake()
    {
        isActive = false;
        isSelected = false;
    }

    // Start is called before the first frame update
    private void Start()
    {
        player = GameObject.FindWithTag(cameraTag).GetComponent<PlayerCamera>();
        itemRender = GetComponent<Renderer>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (isSelected || isActive)
            itemRender.material.SetColor("_BaseColor", Color.white);
        else
            itemRender.material.SetColor("_BaseColor", Color.red);
    }
}
