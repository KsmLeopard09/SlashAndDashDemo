using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private InputAction moveAction;
    [SerializeField] private InputAction dashAction;

    public Vector2 MoveInput { get; private set; }
    public bool DashPressed { get; private set; }

    bool dashPressedFlag = false;
    // Start is called before the first frame update
    private void OnEnable()
    {
        moveAction.Enable();
        dashAction.Enable();
    }
    private void OnDisable()
    {
        moveAction.Disable();
        dashAction.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        MoveInput = moveAction.ReadValue<Vector2>();

        if(dashAction.IsPressed() && !dashPressedFlag)
        {
            DashPressed = true;
            dashPressedFlag = true;
            Debug.Log("Dash Pressed!");
        }
        else if(!dashAction.IsPressed())
        {
            DashPressed = false;
            dashPressedFlag = false;
        }
    }
}
