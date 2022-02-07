using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameras : MonoBehaviour
{
    public GameObject camera1;
    public GameObject MainCamera;
    public float sensitivity = 6f;
    private bool inRange = false;
    bool zmacknul = false;

    void Start()
    {
        MainCamera.SetActive(true);
        camera1.SetActive(false);
    }
 
    void Update()
    {


        Vector2 look = new Vector2(0, Input.GetAxis("Mouse X")) ;
        camera1.transform.Rotate(0,look.y * sensitivity, 0);

        if (Input.GetKeyDown(KeyCode.E) && inRange == true)
        {
            if (!zmacknul)
            {
                camera1.SetActive(true);
                MainCamera.SetActive(false);
                zmacknul = true;
            }
            else
            {
                MainCamera.SetActive(true);
                camera1.SetActive(false);
                zmacknul = false;
            }
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            inRange = true;
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            inRange = false;

        }
    }
}
