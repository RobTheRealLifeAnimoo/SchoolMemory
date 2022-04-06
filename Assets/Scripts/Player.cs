using UnityEngine;

public class Player : MonoBehaviour
{
    private bool isGrounded;

    public GameObject cam;

    CharacterController controller;

    private Vector3 velocity;

    private float gravity = -9.81f;
    float speed = 3f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        controller = GetComponent<CharacterController>();
    }

    void Update() 
    {
        isGrounded = controller.isGrounded;
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = 0f;
        }

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 fwd = cam.transform.forward * vertical;
        Vector3 side = cam.transform.right * horizontal;

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            velocity.y += Mathf.Sqrt(1 * -3.0f * gravity);
        }

        if (Input.GetKey(KeyCode.LeftShift) && isGrounded)
        {
            speed = 6f;
        } else { speed = 3f; }

        Vector3 dir = (fwd + side).normalized;
        dir.y = 0;
        velocity.y += gravity * Time.deltaTime;
        Vector3 distance = dir * speed;

        controller.Move(distance * Time.deltaTime);
        controller.Move(velocity * Time.deltaTime);
    }
}
