using UnityEngine;

public class Kolize : MonoBehaviour
{
    public Animator animator;
    
    bool inRange = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && inRange)
        {
            if (animator.GetBool("stav") == false)
            {
                animator.SetBool("stav", true);
            }
            else
            {
                animator.SetBool("stav", false);
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
