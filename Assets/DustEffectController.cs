using UnityEngine;

public class DustEffectController : MonoBehaviour
{
    public ParticleSystem dustEffect;  
    private PlayerController playerController;
    private Animator animator;

    void Start()
    {
        playerController = GetComponent<PlayerController>(); 
        animator = GetComponent<Animator>(); 

        if (dustEffect == null)
        {
            Debug.LogError("Dust Effect is not assigned!");
        }

        dustEffect.Stop();  
    }

    void Update()
    {
        
        bool isMoving = animator.GetFloat("speed") > 0.1f;
        bool isGrounded = playerController.IsGrounded(); 

        if (isMoving && isGrounded)
        {
            if (!dustEffect.isPlaying)
                dustEffect.Play();  
        }
        else
        {
            dustEffect.Stop();  
        }
    }
}