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
    
    [Header("Configuration")]
    [SerializeField] private float sensitivity;
    [SerializeField] private float smoothing;
    [SerializeField] private float minY;
    [SerializeField] private float maxY;
    
    [Header("Settings")]
    [SerializeField] private string mInputX;
    [SerializeField] private string mInputY;
    
    [SerializeField] private Transform player;

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
    }

    /// <summary>
    /// Handles the mouse movement and camera rotation for the player.
    /// </summary>
    /// <remarks>
    /// This method is responsible for updating the camera rotation based on the player's mouse input. It applies sensitivity and smoothing to the mouse movement, and clamps the vertical rotation to the specified min and max values.
    /// </remarks>
    private void MouseMovement()
    {
        var mouse = new Vector2(Input.GetAxisRaw(mInputX), Input.GetAxisRaw(mInputY));
        
        if (Cursor.lockState == CursorLockMode.Locked)
        {
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
}
