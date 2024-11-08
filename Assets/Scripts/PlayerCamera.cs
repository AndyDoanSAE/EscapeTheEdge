using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    /// <summary>
    /// The PlayerCamera class handles the camera movement and cursor locking for the player.
    /// </summary>
    /// <remarks>
    /// The class uses mouse input to control the camera rotation, with options to adjust the sensitivity, smoothing, and vertical limits.
    /// It also provides functionality to lock and unlock the cursor.
    /// </remarks>
   
    private Vector2 mouseLook;
    private Vector2 mouseSmoothing;

    [Header("Key Binds")]
    [SerializeField] private KeyCode unlockCursorKey;
    [SerializeField] private KeyCode interactionKey;
    
    [Header("Settings")]
    [SerializeField] private float sensitivity;
    [SerializeField] private float smoothing;
    [SerializeField] private float minY;
    [SerializeField] private float maxY;
    [SerializeField] private float interactDistance;

    public bool canInteract;
    
    [SerializeField] private string mInputX;
    [SerializeField] private string mInputY;
    [SerializeField] private string itemTag;
    [SerializeField] private string doorTag;
    
    [SerializeField] private Transform player;
    [SerializeField] private Interactables interactTarget;
    [SerializeField] private Doors doorTarget;

    // Start is called before the first frame update
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    private void Update()
    {
        MouseMovement();
        CursorLock();
        Interaction();
        //Interact();
    }

    /// <summary>
    /// Handles the mouse movement and camera rotation for the player.
    /// </summary>
    /// <remarks>
    /// This method is responsible for updating the camera rotation based on the player's mouse input. It applies sensitivity and smoothing to the mouse movement, and clamps the vertical rotation to the specified min and max values.
    /// </remarks>
    private void MouseMovement()
    {
        if (Cursor.lockState == CursorLockMode.Locked)
        {
            var mouse = new Vector2(Input.GetAxisRaw(mInputX), Input.GetAxisRaw(mInputY));

            mouse = Vector2.Scale(mouse, new Vector2(sensitivity * smoothing, sensitivity * smoothing));
            mouseSmoothing.x = Mathf.Lerp(mouseSmoothing.x, mouse.x, 1f / smoothing);
            mouseSmoothing.y = Mathf.Lerp(mouseSmoothing.y, mouse.y, 1f / smoothing);
            mouseLook += mouseSmoothing;
            mouseLook.y = Mathf.Clamp(mouseLook.y, minY, maxY);

            transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
            player.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, player.transform.up);
        }
    }
    
    /// <summary>
    /// Handles the locking and unlocking of the cursor based on user input.
    /// </summary>
    /// <remarks>
    /// This method is responsible for toggling the cursor lock state between locked and unlocked. When the cursor is locked, the mouse cursor is hidden and the player's camera rotation is controlled by the mouse movement. When the cursor is unlocked, the mouse cursor is visible and the player's camera rotation is not affected by the mouse.
    /// 
    /// The cursor is locked when the player clicks the left mouse button. The cursor is unlocked when the player presses the key specified by the `unlockCursor` variable.
    /// </remarks>
    private void CursorLock()
    {
        if (Input.GetKeyDown(unlockCursorKey))
        {
            Cursor.lockState = CursorLockMode.None;
        }
        else if (Input.GetMouseButtonDown(0))
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    private void Interaction()
    {
        Debug.DrawRay(transform.position, transform.forward * interactDistance, Color.red);

        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hitObject, interactDistance))
        {
            Debug.Log("Item in range");

            if (hitObject.transform.gameObject.CompareTag(itemTag))
            {
                interactTarget = hitObject.transform.gameObject.GetComponent<Interactables>();
                canInteract = true;
                interactTarget.isSelected = true;

                if (canInteract)
                {
                    if (Input.GetKeyDown(interactionKey))
                    {
                        Debug.Log("Weeeeeeeee");
                        //player.transform.position = interactTarget.destination;
                        interactTarget.isActive = true;
                    }
                }
            }
            /*else 
            {
                interactTarget.isSelected = false;
                interactTarget = null;
                canInteract = false;
            }*/

            if (hitObject.transform.gameObject.CompareTag(doorTag))
            {
                doorTarget = hitObject.transform.gameObject.GetComponent<Doors>();
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
                doorTarget = null;
            }

            canInteract = false;
        }
    }

    /*private void Interact()
    {
        if (canInteract)
        {
            if (Input.GetKeyDown(interactionKey) && interactTarget.gameObject.CompareTag(buttonTag))
            {
                Debug.Log("Weeeeeeeee");
                player.transform.position = interactTarget.destination;
            }
        }
    }*/
}
