using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Key_Doors : Doors
{
    [SerializeField] private List<string> keysRequired = new List<string>();
    [SerializeField] private int activeKeys;
    
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        activeKeys = 0;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        if (activeKeys == keysRequired.Count)
            canOpen = true;
    }

    public override void Activation()
    {
        var playerInventory = FindObjectOfType<Player_Inventory>();
        
        Debug.Log("Number of keys required: " + keysRequired.Count);

        if (keysRequired.Count <= 0)
            return;

        foreach (string key in keysRequired)
        {
            if (playerInventory.keysHeld.Contains(key))
                activeKeys++;
        }

        Debug.Log("Number of correct keys held: " + activeKeys);
        
        if (activeKeys < keysRequired.Count)
        {
            activeKeys = 0;
            Debug.Log("Door is locked");
        }
        else
        {
            activeKeys = keysRequired.Count;
            Debug.Log("Door is opened!");
            Destroy(gameObject);
        }
    }
}
