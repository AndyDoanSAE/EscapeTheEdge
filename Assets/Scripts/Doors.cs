using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour
{
    public List<Interactables> criteria = new List<Interactables>();
    public bool canOpen;
    public int activeButtons;

    // Start is called before the first frame update
    private void Start()
    {
        canOpen = false;
        activeButtons = 0;
    }

    // Update is called once per frame
    private void Update()
    {
        if (activeButtons == criteria.Count)
            canOpen = true;
    }

    public void Activation()
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
                Debug.Log("Door is opened!");
            }
        }
    }
}
