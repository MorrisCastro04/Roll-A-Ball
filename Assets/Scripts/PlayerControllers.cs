using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControllers : MonoBehaviour
{
    Rigidbody rb;
    public float velocidad;
    float moveX, moveY;
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
        rb.AddForce(movimiento * velocidad);
    }

    void OnMove(InputValue moveValue)
    {
        Vector2 move = moveValue.Get<Vector2>();
        moveX = move.x;
        moveY = move.y;
    }
}
