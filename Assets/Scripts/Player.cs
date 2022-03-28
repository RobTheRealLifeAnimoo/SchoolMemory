using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float jumpPower=3f;
    public bool isGrounded;
    new private Rigidbody rigidbody;

    Camera cam;
    CharacterController controller;
    float sensitivity = 2f;
    float speed = 3f;
    float sprintSpeed=6f;
    private float realSpeed;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        controller = GetComponent<CharacterController>();
        cam = GetComponentInChildren<Camera>();
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        

        realSpeed = Input.GetKey(KeyCode.LeftShift) ? sprintSpeed : speed;

        if (isGrounded) 
        {
            if (Input.GetKeyDown(KeyCode.Space)) 
            {
                rigidbody.AddForce(Vector3.up * jumpPower);
            }
        }
    }
    void FixedUpdate() 
    {
        transform.Translate(realSpeed * Input.GetAxis("Horizontal") * Time.deltaTime, 0f, realSpeed * Input.GetAxis("Vertical") * Time.deltaTime);
        //Vector3 move = transform.forward * Input.GetAxis("Vertical") * speed + transform.right * Input.GetAxis("Horizontal") * speed;
        Vector2 look = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

        cam.transform.Rotate(-look.y * sensitivity, 0, 0);
        controller.transform.Rotate(0, look.x * sensitivity, 0);
        //controller.SimpleMove(move);

        Vector3 currentRotation = cam.transform.localEulerAngles;
        if (currentRotation.x > 180) currentRotation.x -= 360;
        currentRotation.x = Mathf.Clamp(currentRotation.x, -70, 70);
        cam.transform.localRotation = Quaternion.Euler(currentRotation);
    }
    void OnCollisionEnter(Collision other) 
    {
        if (other.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }
    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Ground")
        {
            isGrounded = false;
        }
    }
}
