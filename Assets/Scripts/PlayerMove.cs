using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMove : MonoBehaviour
{
    [SerializeField] private PlayerInput input;
    private Rigidbody2D rb;
    [SerializeField] private float movementSpeed;

    public float MovementSpeed
    { get => movementSpeed; 
      set => movementSpeed = value; 
    }

    private bool facingRight;

    public bool FacingRight
    {
        get => facingRight;
        private set => facingRight = value;
    }
    // Start is called before the first frame update
    void Start()
    {
        facingRight = true;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void FixedUpdate()
    {
        Vector2 move = input.MoveInput;
        rb.velocity = new Vector2(move.x * movementSpeed, rb.velocity.y);
        HandleFlip(move.x);
    }
    void Flip()
    {
        Vector3 currentScale = transform.localScale;
        currentScale.x *= -1;
        transform.localScale = currentScale;


        facingRight = !facingRight;
    }
    void HandleFlip(float horizontalInput)
    {
        if ((horizontalInput < 0 && facingRight) || (horizontalInput > 0 && !facingRight))
        {
            Flip();
        }
    }
}
