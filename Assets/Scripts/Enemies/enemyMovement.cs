using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovement : MonoBehaviour {
    [SerializeField] float eMoveSpeed = 5f;

    public player moveToPlayer;

    void Start() {
        if (moveToPlayer==null) {
            moveToPlayer = FindObjectOfType<player>();
        }
    }
    void Update() {
        Vector3 direction = (moveToPlayer.transform.position - transform.position).normalized;
        transform.position += direction*eMoveSpeed*Time.deltaTime;
    }
}