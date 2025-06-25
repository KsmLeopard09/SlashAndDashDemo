using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private InputAction moveAction;
    [SerializeField] private InputAction dashAction;
    [SerializeField] private InputAction attackAction;
    public Vector2 MoveInput { get; private set; }
    public bool DashPressed { get; private set; }
    public bool AttackPressed { get; private set; }

    bool dashPressedFlag = false;
    bool attackPressed = false;
    // Start is called before the first frame update
    private void OnEnable()
    {
        moveAction.Enable();
        dashAction.Enable();
        attackAction.Enable();
    }
    private void OnDisable()
    {
        moveAction.Disable();
        dashAction.Disable();
        attackAction.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        MoveInput = moveAction.ReadValue<Vector2>();

        if(dashAction.IsPressed() && !dashPressedFlag && Mathf.Abs(moveAction.ReadValue<Vector2>().x) > 0)
        {
            DashPressed = true;
            dashPressedFlag = true;
        }
        else if(!dashAction.IsPressed())
        {
            DashPressed = false;
            dashPressedFlag = false;
        }
        if (attackAction.IsPressed() && !attackPressed)
        {
            attackPressed = true;
            AttackPressed = true;
        }
        else if(!attackAction.IsPressed())
        {
            attackPressed = false;
            AttackPressed = false;
        }

    }
}
