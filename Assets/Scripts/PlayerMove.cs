using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMove : MonoBehaviour
{
    public InputAction moveAction, dashAction;
    public Vector2 moveValue;
    [SerializeField] Rigidbody2D rb;
    public float movementSpeed;
    [SerializeField] Animator animator, armourAnimator;
    bool facingRight;
    bool dashPressed;

    // Start is called before the first frame update
    void Start()
    {
        dashPressed = false;
        facingRight = true;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        moveValue.x = moveAction.ReadValue<Vector2>().x;
        moveValue.y = moveAction.ReadValue<Vector2>().y;
        if(moveValue.x < 0 && facingRight)
        {
            Flip();
        }
        if(moveValue.x > 0 && !facingRight)
        {
            Flip();
        }
        if(Mathf.Abs(moveValue.x) > 0.1)
        {
            animator.SetBool("Moving", true);
            armourAnimator.SetBool("Moving", true);
        }
        else
        {
            animator.SetBool("Moving", false);
            armourAnimator.SetBool("Moving", false);
        }
        if(dashAction.IsPressed() && dashPressed == false)
        {
            Debug.Log("Dash pressed!");
            dashPressed = true;
        }
        else if( !dashAction.IsPressed())
        {
            dashPressed = false;
        }
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveValue.x * movementSpeed, rb.velocity.y);
    }
    private void OnEnable()
    {
        dashAction.Enable();
        moveAction.Enable();
    }
    private void OnDisable()
    {
        dashAction.Disable();
        moveAction.Disable();
    }
    void Flip()
    {
        Vector3 currentScale = transform.localScale;
        currentScale.x *= -1;
        transform.localScale = currentScale;


        facingRight = !facingRight;
    }
}
