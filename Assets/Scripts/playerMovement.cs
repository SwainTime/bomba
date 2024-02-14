using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public CharacterController characterController;
    public float speed = 10f, gravity = -9.81f, groundDistance = 0.4f, jumpHeight = 0.3f;
    public float crouchY, crouchspeed;
    float normalY;
    bool isTouching;
    public Transform groundCheck;
    public LayerMask groundMask;
    public GameObject footStep;
    Vector3 velocity;
    // Start is called before the first frame update
    void Start()
    {
        normalY = transform.localScale.y;
    }

    // Update is called once per frame
    void Update()
    {
        isTouching = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isTouching && velocity.y < 0)
            velocity.y = -2f;

        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");

        if(Input.GetKey(KeyCode.LeftShift))
            speed = 40f;
        else
            speed = 10f;

        if(Input.GetKeyDown(KeyCode.LeftControl))
        {
            transform.localScale = new Vector3(transform.localScale.x, crouchY, transform.localScale.z);
            rb.AddForce(new Vector3(0, -5f, 0),ForceMode.Impulse);
            speed = crouchspeed;
        }
        else if(Input.GetKeyUp(KeyCode.LeftControl))
        {
            transform.localScale = new Vector3(transform.localScale.x, normalY, transform.localScale.z);
            speed = 10;
        }
        
        if(Input.GetKeyDown(KeyCode.Space) && isTouching)
            velocity.y = Mathf.Sqrt(-2 * jumpHeight * gravity);
        Vector3 move = transform.right * hor + transform.forward * ver;

        if(move != new Vector3(0, 0, 0))
            footStep.SetActive(true);
        else    
            footStep.SetActive(false);

        characterController.Move(move * Time.deltaTime * speed);

        velocity.y += gravity * Time.deltaTime;

        characterController.Move(velocity * Time.deltaTime);
    }
}
