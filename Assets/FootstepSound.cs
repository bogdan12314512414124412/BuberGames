using UnityEngine;

public class FootstepSound : MonoBehaviour
{
    public AudioSource stepSound;  
    public float stepInterval = 0.5f;  
    private float timeSinceLastStep = 0f;  

    void Update()
    {
        
        bool isMoving = Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0;

        if (isMoving)
        {
            
            if (timeSinceLastStep >= stepInterval)
            {
                if (!stepSound.isPlaying)  
                {
                    stepSound.Play();  
                }
                timeSinceLastStep = 0f;  
            }
        }
        else
        {
            
            if (stepSound.isPlaying)
            {
                stepSound.Stop();
            }
        }

        
        timeSinceLastStep += Time.deltaTime;
    }
}