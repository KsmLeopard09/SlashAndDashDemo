using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    [SerializeField] private PlayerInput input;
    [SerializeField] private PlayerMove movement;
    [SerializeField] private float dashDuration = 0.2f;
    [SerializeField] private float dashSpeed = 15f;
    [SerializeField] private float dashCooldown = 1f;
    [SerializeField] private DashAfterImage afterImageGenerator;
    [SerializeField] private PlayerAttack attackHandler;

    private bool canDash = true;
    public bool dashing { get; private set; }
    public float originalSpeed { get; private set; }
    public float DashDuration
    {
        get => dashDuration;
        private set => dashDuration = value;
    }
    public float DashCooldown
    {
        get => dashCooldown;
        private set => dashCooldown = value;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        CheckDash();
    }
    void CheckDash()
    {
        if (input.DashPressed && canDash && !attackHandler.isAttacking)
        {
            dashing = true;
            StartCoroutine(Dash());
        }
    }
    private IEnumerator Dash()
    {
        canDash = false;
        originalSpeed = movement.MovementSpeed;
        movement.MovementSpeed = dashSpeed;
        yield return new WaitForSeconds(dashDuration);
        dashing = false;
        movement.MovementSpeed = originalSpeed;

        yield return new WaitForSeconds(dashCooldown);

        canDash = true;
    }
}
