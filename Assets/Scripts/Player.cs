using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Camera cam;
    CharacterController controller;
    float sensitivity = 2f;
    float speed = 3f;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        controller = GetComponent<CharacterController>();
        cam = GetComponentInChildren<Camera>(); 
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 move = transform.forward * Input.GetAxis("Vertical") * speed + transform.right * Input.GetAxis("Horizontal") * speed;
        Vector2 look = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

        cam.transform.Rotate(-look.y * sensitivity, 0, 0);
        controller.transform.Rotate(0, look.x * sensitivity, 0);
        controller.SimpleMove(move);
        
        Vector3 currentRotation = cam.transform.localEulerAngles;
        if (currentRotation.x > 180) currentRotation.x -= 360;
        currentRotation.x = Mathf.Clamp(currentRotation.x, -70, 70);
        cam.transform.localRotation = Quaternion.Euler(currentRotation);
    }
}
