using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControllers : MonoBehaviour
{
    Rigidbody rb;
    public float velocidad;
    float moveX, moveY;

    public float jumpForce;
    public int MaxJumps = 2;
    private int countJump = 0;
    private bool isGrounded;
    public float airControl = 0.5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        Vector3 movimiento = new Vector3(moveX, 0, moveY);

        if (isGrounded)
        {
            rb.AddForce(movimiento * velocidad);
        }
        else
        {
            rb.AddForce(movimiento * velocidad *airControl);
        }

        rb.linearVelocity = new Vector3(rb.linearVelocity.x * 0.98f, rb.linearVelocity.y, rb.linearVelocity.z * 0.98f);
    }

    void OnMove(InputValue moveValue)
    {
        Vector2 move = moveValue.Get<Vector2>();
        moveX = move.x;
        moveY = move.y;
    }

    void OnJump(InputValue jumpValue)
    {
        if (countJump < MaxJumps)
        {
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0, rb.linearVelocity.y);
            rb.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
            countJump++;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            countJump = 0;
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("points"))
        {
            other.gameObject.SetActive(false);
        }
    }
}
