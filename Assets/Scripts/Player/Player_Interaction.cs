using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Interaction : MonoBehaviour
{
    [Header("Tags")]
    [SerializeField] private string itemTag;
    [SerializeField] private string doorTag;
    
    [Header("Interact Settings")]
    [SerializeField] private float interactDistance;
    [SerializeField] private KeyCode interactionKey;
    
    [Header("References")]
    [SerializeField] private Interactables interactTarget;
    [SerializeField] private Doors doorTarget;
    [SerializeField] private Transform cameraPos;
    
    [Header("Checks")]
    public bool canInteract;

    private void Update()
    {
        Interaction();
    }

    private void Interaction()
    {
        Debug.DrawRay(cameraPos.transform.position, cameraPos.transform.forward * interactDistance, Color.red);

        if (Physics.Raycast(cameraPos.transform.position, cameraPos.transform.forward, out RaycastHit hitObject, interactDistance))
        {
            if (hitObject.transform.gameObject.CompareTag(itemTag))
            {
                Debug.Log("Item in range");
                interactTarget = hitObject.transform.gameObject.GetComponent<Interactables>();
                canInteract = true;
                interactTarget.isSelected = true;

                if (canInteract)
                {
                    if (Input.GetKeyDown(interactionKey))
                    {
                        Debug.Log(gameObject + " is active");
                        //player.transform.position = interactTarget.destination;
                        interactTarget.isActive = true;
                    }
                }
            }

            if (hitObject.transform.gameObject.CompareTag(doorTag))
            {
                doorTarget = hitObject.transform.gameObject.GetComponent<Doors>();
                doorTarget.isSelected = true;
                canInteract = true;

                if (canInteract)
                {
                    if (Input.GetKeyDown(interactionKey))
                    {
                        Debug.Log("Trying to open the door");
                        doorTarget.Activation();
                    }
                }
            }
        }
        else 
        {
            if (interactTarget)
            {
                interactTarget.isSelected = false;
                interactTarget = null;
            }

            if (doorTarget)
            {
                doorTarget.isSelected = false;
                doorTarget = null;
            }

            canInteract = false;
        }
    }
}
