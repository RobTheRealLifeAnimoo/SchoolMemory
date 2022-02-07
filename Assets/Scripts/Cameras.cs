using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameras : MonoBehaviour
{
    Camera cam;
    public GameObject camera1;
    public GameObject MainCamera;
    public float sensitivity = 6f;
    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponentInChildren<Camera>();
        MainCamera.SetActive(true);
        camera1.SetActive(false);
    }
    bool zmackut = false;
    // Update is called once per frame
    void Update()
    {


        Vector2 look = new Vector2(0, Input.GetAxis("Mouse Y")) ;
        cam.transform.Rotate(0,-look.y * sensitivity, 0);
        //Vector3 currentRotation = cam.transform.localEulerAngles;
        //if ((currentRotation.y > 170) || (currentRotation.y < 100)) 
        //currentRotation.y = Mathf.Clamp(0,currentRotation.y, 70);
        //cam.transform.localRotation = Quaternion.Euler(currentRotation);

        if (Input.GetKey(KeyCode.E))
        {
            if (!zmackut)
            {
                camera1.SetActive(true);
                MainCamera.SetActive(false);
                zmackut = true;
            }
            else
            {
                MainCamera.SetActive(true);
                camera1.SetActive(false);
                zmackut = false;
            }
        }
        
    }
    /*private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Mrka");
            
        }
    }*/
    
}
