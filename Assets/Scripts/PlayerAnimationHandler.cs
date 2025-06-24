using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationHandler : MonoBehaviour
{
    [SerializeField] private PlayerInput input;
    [SerializeField] private Animator playerAnimator;
    [SerializeField] private Animator armourAnimator;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        UpdateMovementAndAnimation(input.MoveInput.x);
    }
    void UpdateMovementAndAnimation(float horizontalInput)
    {
        bool isMoving = Mathf.Abs(horizontalInput) > 0.1;
        playerAnimator.SetBool("Moving", isMoving);
        armourAnimator.SetBool("Moving", isMoving);
    }
}
