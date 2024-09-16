using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour {
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] Animator animator;

    public Transform spriteTransform;

    private Vector3 movement;
    float movementx;
    float movementy;

    void Update() {
        movementx = Input.GetAxisRaw("Horizontal");
        movementy = Input.GetAxisRaw("Vertical");
        movement = new Vector3(movementx, movementy, 0).normalized;
        //anim
        if (movementx !< 0 || movementx !> 0) {
            animator.SetBool("isMoving", true);
        } else {
            animator.SetBool("isMoving", false);
        }
        if (movementx > 0 ) {
            spriteTransform.localScale = new Vector3(-1f,1f,1f); //face right
        } else {
            spriteTransform.localScale = new Vector3(1f,1f,1f); //face left
        }
    }
    void FixedUpdate() {
        transform.position += movement*moveSpeed*Time.fixedDeltaTime;
    }
}