using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour {
    [SerializeField] float moveSpeed = 10f;

    private Vector3 movement;
    float movementx;
    float movementy;

    void Start() {
        
    }
    void Update() {
        movementx = Input.GetAxisRaw("Horizontal");
        movementy = Input.GetAxisRaw("Vertical");
        movement = new Vector3(movementx, movementy, 0);
    }
    void FixedUpdate() {
        transform.position += movement*moveSpeed*Time.fixedDeltaTime;
    }
}