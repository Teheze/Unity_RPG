using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;
    public float groundDrag;

    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;
    bool readyToJump;

    // Timer for step sound
    private float timer = 0.0f;

    [HideInInspector] public float walkSpeed = 2.0f; // Walk speed
    [HideInInspector] public float sprintSpeed = 4.0f; // Sprint speed

    [Header("Keybinds")]
    public KeyCode jumpKey = KeyCode.Space;
    public KeyCode sprintKey = KeyCode.LeftShift;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded;

    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    Rigidbody rb;

    public HungerBar hungerBar; // Reference to the HungerBar
    public float speedMultiplier = 1f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        readyToJump = true;
        hungerBar = FindObjectOfType<HungerBar>(); // Ensure HungerBar is found
    }

    private void Update()
    {
        // Ground check
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.3f, whatIsGround);
        MyInput();
        SpeedControl();

        // Handle drag
        if (grounded)
            rb.drag = groundDrag;
        else
            rb.drag = 0;

        bool leftClicked = Input.GetKey(KeyCode.Mouse0);
        timer += Time.deltaTime;

        // Play step sound
        if (grounded && moveDirection.magnitude > 0)
        {
            float stepInterval = Input.GetKey(sprintKey) ? 0.3f : 0.6f;
            StepSound(stepInterval);
        }
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void StepSound(float stepTime)
    {
        if (timer >= stepTime)
        {
            int stepIndex = Random.Range(0, 7); // Generate a random number between 0 and 6
            if (stepTime == 0.6f)
            {
                AudioManager.Instance.PlaySFX("Step" + stepIndex, 0.3f);
            }
            else
                AudioManager.Instance.PlaySFX("Step" + stepIndex, 0.5f);
            timer = 0.0f;
        }
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        // when to jump
        if (Input.GetKeyDown(jumpKey) && readyToJump && grounded)
        {
            readyToJump = false;
            Jump();
            if (hungerBar != null)  // Ensure HungerBar is linked
            {
                hungerBar.DecreaseHunger(0.3f);  // Decrease hunger immediately on jump
            }
            Invoke(nameof(ResetJump), jumpCooldown);
        }
    }

    private void MovePlayer()
    {
        // calculate movement direction
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        // Calculate speed multiplier when sprinting
        float speedMultiplier = 1f;
        if (Input.GetKey(sprintKey) && moveDirection.magnitude > 0)
        {
            speedMultiplier = 4f; // Increase speed for sprinting

            hungerBar.DecreaseHunger(0.1f * Time.fixedDeltaTime);  //Decrease hunger while sprinting
        }

        // on ground
        if (grounded)
        {
            rb.AddForce(moveDirection.normalized * moveSpeed * speedMultiplier * 10f, ForceMode.Force);
        }
        // in air
        else if (!grounded)
        {
            rb.AddForce(moveDirection.normalized * moveSpeed * speedMultiplier * 10f * airMultiplier, ForceMode.Force);
        }
    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        // limit velocity if needed
        if (flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }

    private void Jump()
    {
        // reset y velocity
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
        AudioManager.Instance.PlaySFX("Jump");
    }

    private void ResetJump()
    {
        readyToJump = true;
    }
}
