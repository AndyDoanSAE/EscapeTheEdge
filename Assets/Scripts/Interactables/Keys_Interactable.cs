using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keys_Interactable : Interactables
{
    public string keyID;

    // [SerializeField] private Player_Interaction player;

    protected override void Awake()
    {
        base.Awake();
    }

    // Start is called before the first frame update
    protected override void Start()
    {
        
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }

    protected override void Selected()
    {
        base.Selected();
    }

    public void Despawn()
    {
        Destroy(gameObject);
    }
}
