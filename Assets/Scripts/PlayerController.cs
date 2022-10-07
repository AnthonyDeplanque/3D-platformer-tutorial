using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

  public CharacterController characterController;
  public float moveSpeed;
  public float jumpForce;
  public float gravity;
  private Vector3 moveDirection;
  public Animator anim;
  bool isWalking = false;
  void Start()
  {
    characterController = GetComponent<CharacterController>();
    anim = GetComponent<Animator>();
  }
  public Vector3 getMoveDirection()
  {
    return moveDirection;
  }
  public void setMoveDirection(Vector3 moveDirection)
  {
    this.moveDirection = moveDirection;
  }
  public float getJumpForce()
  {
    return jumpForce;
  }

  void Update()
  {
    anim.SetBool("isWalking", isWalking);
    moveDirection = new Vector3(
        Input.GetAxis("Horizontal") * moveSpeed,
        moveDirection.y,
        Input.GetAxis("Vertical") * moveSpeed
        );
    moveDirection.y -= gravity * Time.deltaTime;

    // Jump
    if (Input.GetButtonDown("Jump") && characterController.isGrounded)
    {
      moveDirection.y = jumpForce;
    }

    // if movement
    if (moveDirection.x != 0 || moveDirection.z != 0)
    {
      isWalking = true;
      // Rotation with quaternion slerp in the good direction
      transform.rotation = Quaternion.Slerp(
          transform.rotation,
          Quaternion.LookRotation(
              new Vector3(moveDirection.x, 0, moveDirection.z)
              ),
              0.15f);
    }
    else
    {
      isWalking = false;
    }
    // applying movement
    characterController.Move(moveDirection * Time.deltaTime);

  }
}
