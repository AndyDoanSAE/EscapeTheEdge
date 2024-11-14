using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Player_Interaction : MonoBehaviour
{
    [Header("Tags")]
    [SerializeField] private string itemTag;
    [SerializeField] private string doorTag;
    [SerializeField] private string keyTag;
    
    [Header("Interact Settings")]
    [SerializeField] private float interactDistance;
    [SerializeField] private KeyCode interactionKey;
    
    [Header("References")]
    [SerializeField] private Interactables interactTarget;
    [SerializeField] private Doors doorTarget;
    [SerializeField] private Keys_Interactable keyTarget;
    [SerializeField] private Transform cameraPos;
    [SerializeField] private Player_Inventory playerInventory;
    
    [Header("Checks")]
    public bool canInteract;

    private void Awake()
    {
        playerInventory = GetComponent<Player_Inventory>();
    }

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
                interactTarget = hitObject.transform.gameObject.GetComponent<Interactables>();
                canInteract = true;
                interactTarget.isSelected = true;

                if (canInteract)
                {
                    Debug.Log(gameObject + " is interactable");
                    if (Input.GetKeyDown(interactionKey))
                    {
                        Debug.Log(gameObject + " is active");
                        interactTarget.isActive = true;
                    }
                }
            }
            else
            {
                if (interactTarget)
                {
                    Debug.Log(interactTarget + " is out of range");
                    interactTarget.isSelected = false;
                    interactTarget = null;
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
            else
            {
                if (doorTarget)
                {
                    doorTarget.isSelected = false;
                    doorTarget = null;  
                }
            }
            
            if (hitObject.transform.gameObject.CompareTag(keyTag))
            {
                keyTarget = hitObject.transform.gameObject.GetComponent<Keys_Interactable>();
                keyTarget.isSelected = true;
                canInteract = true;

                if (canInteract)
                {
                    Debug.Log(keyTarget + " is interactable");
                    if (Input.GetKeyDown(interactionKey))
                    {
                        Debug.Log("Obtained " + keyTarget.keyID);
                        playerInventory.keysHeld.Add(keyTarget.keyID);
                        keyTarget.isSelected = false;
                        keyTarget.Despawn();
                    }
                }
            }
            else
            {
                if (keyTarget)
                {
                    Debug.Log(keyTarget + " is out of range");
                    keyTarget.isSelected = false;
                    keyTarget = null;  
                }
            }
        }
        else 
            canInteract = false;
    }
}
