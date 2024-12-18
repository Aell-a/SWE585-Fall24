using UnityEngine;

public class RunController : MonoBehaviour
{
    public Animator animator; 
    private bool isRunning = false; 

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            isRunning = !isRunning; 
            animator.SetBool("isRunning", isRunning); 
        }
    }
}
