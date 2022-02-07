using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kolize : MonoBehaviour
{
    Animator animator;
    
    bool otevreno;
    // Start is called before the first frame update
    void Start()
    {
        
        otevreno = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Kruuuuug");
            if (Input.GetKeyDown(KeyCode.F))
            {
                if (otevreno) 
                {
                    animator.SetBool("stav", true);
                    otevreno = false; 
                }
                else 
                {
                    animator.SetBool("stav", false);
                    otevreno = true; 
                }
            }
        }
        
    }
}
