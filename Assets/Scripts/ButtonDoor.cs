using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonDoor : Doors
{
    [SerializeField] private List<Interactables> criteria = new List<Interactables>();
    [SerializeField] private int activeButtons;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        activeButtons = 0;
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
        if (activeButtons == criteria.Count)
            canOpen = true;
    }

    public override void Activation()
    {
        if (criteria.Count > 0)
        {
            foreach (Interactables button in criteria)
            {
                button.GetComponent<Interactables>();

                if (button.isActive)
                    activeButtons++;
            }

            Debug.Log("Number of active buttons: " + activeButtons);

            if (activeButtons < criteria.Count)
            {
                activeButtons = 0;
                Debug.Log("Door is locked");
            }
            else
            {
                activeButtons = criteria.Count;
                Debug.Log("Door is opened!");
                Destroy(gameObject);
            }
        }
    }
}
