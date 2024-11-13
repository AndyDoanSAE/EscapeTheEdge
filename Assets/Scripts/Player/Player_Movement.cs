using System;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    [SerializeField] private float speed;

    [SerializeField] private string moveInput;
    [SerializeField] private string strafeInput;

    private RaycastHit hitObject;

    // private Rigidbody rb;
    
    // Start is called before the first frame update
    private void Start()
    {
        // rb = GetComponent<Rigidbody>();
    }

    // Fixed update every frame
    private void FixedUpdate()
    {
        Movement();
    }

    private void Movement()
    {
        var move = Input.GetAxisRaw(moveInput);
        var strafe = Input.GetAxisRaw(strafeInput);
        
        move *= speed * Time.deltaTime;
        strafe *= speed * Time.deltaTime;
        
        transform.Translate(strafe, 0, move);
    }
}
