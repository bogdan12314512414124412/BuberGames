using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator animator;
    private Rigidbody rb;
    private Transform cameraTransform;

    public float speed = 5f;   // Швидкість руху
    public float rotationSpeed = 10f;  // Швидкість повороту
    public float gravity = 9.81f; // Гравітація
    private Vector3 velocity;

    // Клавіші як KeyCode
    private KeyCode moveUp;
    private KeyCode moveDown;
    private KeyCode moveLeft;
    private KeyCode moveRight;
    private KeyCode jump;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        cameraTransform = Camera.main?.transform;

        if (cameraTransform == null)
        {
            Debug.LogError("Camera not found! Ensure there is a main camera in the scene.");
        }

        rb.freezeRotation = true;

        // Завантаження клавіш як KeyCode
        moveUp = GetKeyCode("MoveUp", KeyCode.W);
        moveDown = GetKeyCode("MoveDown", KeyCode.S);
        moveLeft = GetKeyCode("MoveLeft", KeyCode.A);
        moveRight = GetKeyCode("MoveRight", KeyCode.D);
        jump = GetKeyCode("Jump", KeyCode.Space);
    }

    void Update()
    {
        MovePlayer();
        RotateCamera();
    }

    void MovePlayer()
    {
        float h = 0f;
        float v = 0f;

        if (Input.GetKey(moveLeft)) h = -1f;
        if (Input.GetKey(moveRight)) h = 1f;
        if (Input.GetKey(moveUp)) v = 1f;
        if (Input.GetKey(moveDown)) v = -1f;

        Vector3 directionVector = new Vector3(h, 0, v).normalized;

        if (directionVector.magnitude > 0.1f)
        {
            Vector3 moveDirection = cameraTransform.forward * v + cameraTransform.right * h;
            moveDirection.y = 0;
            moveDirection.Normalize();

            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            velocity.x = moveDirection.x * speed;
            velocity.z = moveDirection.z * speed;

            animator.SetFloat("speed", 1f);
        }
        else
        {
            animator.SetFloat("speed", 0f);
            velocity.x = 0;
            velocity.z = 0;
        }

        if (!IsGrounded())
        {
            velocity.y -= gravity * Time.deltaTime;
        }
        else
        {
            velocity.y = -0.1f;
        }

        // Стрибок
        if (Input.GetKeyDown(jump) && IsGrounded())
        {
            velocity.y = Mathf.Sqrt(gravity * 2f);
        }

        // Застосовуємо швидкість до Rigidbody
        rb.linearVelocity = velocity;
    }

    void RotateCamera()
    {
        if (cameraTransform == null) return;

        Vector3 targetPosition = transform.position - transform.forward * 5f + Vector3.up * 3f;
        cameraTransform.position = Vector3.Lerp(cameraTransform.position, targetPosition, Time.deltaTime * rotationSpeed);
        cameraTransform.LookAt(transform.position + Vector3.up * 1.5f);
    }

    public bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, 1.1f);
    }

    // Безпечне перетворення рядка у KeyCode з fallback
    private KeyCode GetKeyCode(string key, KeyCode defaultKey)
    {
        string savedKey = PlayerPrefs.GetString(key, defaultKey.ToString());
        try
        {
            return (KeyCode)System.Enum.Parse(typeof(KeyCode), savedKey.Trim(), true);
        }
        catch
        {
            Debug.LogWarning($"Invalid key string in PlayerPrefs: '{savedKey}', using default: {defaultKey}");
            return defaultKey;
        }
    }
}