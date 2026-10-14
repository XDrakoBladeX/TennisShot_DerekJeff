using UnityEngine;

public class TennisPlayerMovement : MonoBehaviour
{
    private Animator animator;
    public float walkSpeed = 3f;
    public float runSpeed = 6f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()

    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()

    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            animator.SetTrigger("Taunt");
        }
        bool isMoving = Input.GetKey(KeyCode.W) ||
                      Input.GetKey(KeyCode.A) ||
                      Input.GetKey(KeyCode.S) ||
                      Input.GetKey(KeyCode.D);

        if (!isMoving)
        {
            animator.SetFloat("Speed", 0f);
        }
        else if (Input.GetKey(KeyCode.LeftShift))
        {
            animator.SetFloat("Speed", 2f);
        }
        else
        {
            animator.SetFloat("Speed", 1f);
                    // Read movement direction
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");

            // Create our movement direction
            Vector3 movement = new Vector3(horizontal, 0f, vertical).normalized;

            // Choose walking or running speed
            float currentSpeed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : walkSpeed;

            // Actually move our character
            transform.position += movement * currentSpeed * Time.deltaTime;

            if (movement.sqrMagnitude > 0.01f)
            {
                transform.rotation = Quaternion.LookRotation(movement);
            }
        }
    }

}