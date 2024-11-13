using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour
{
    public bool canOpen;

    // Start is called before the first frame update
    public virtual void Start()
    {
        canOpen = false;
    }

    // Update is called once per frame
    public virtual void Update()
    {
        
    }

    public virtual void Activation()
    {
        
    }
}
