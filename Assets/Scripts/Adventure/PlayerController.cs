using Palmmedia.ReportGenerator.Core.Reporting.Builders;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] float moveSpeed;
    [SerializeField] InputActionReference move;
    [SerializeField] Animator anim;
    Vector3 moveDir;

    private void FixedUpdate()
    {
        rb.velocity = new Vector3(moveDir.x * moveSpeed, 0, moveDir.z * moveSpeed);
    }
    public void Move(InputAction.CallbackContext context)
    {
        moveDir = move.action.ReadValue<Vector3>();
        bool isMoving = moveDir.sqrMagnitude > 0.01f;

        anim.SetBool("isWalking", isMoving);
        anim.SetFloat("Input_X", moveDir.x);
        anim.SetFloat("Input_Z", moveDir.z);

        if (isMoving)
        {
            anim.SetFloat("LastInput_X", moveDir.x);
            anim.SetFloat("LastInput_Z", moveDir.z);
        }
    }
}
