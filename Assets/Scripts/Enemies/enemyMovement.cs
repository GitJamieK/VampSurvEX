using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovement : MonoBehaviour {
    [SerializeField] float eMoveSpeed = 5f;
    [SerializeField] float zzFrequency = 5f; //oscillate faster
    [SerializeField] float zzAmplitude = 1f; //wider pattern + more noticeable

    public player moveToPlayer;
    private float zzTimer = 0f;

    void Start() {
        if (moveToPlayer==null) {
            moveToPlayer = FindObjectOfType<player>();
        }
    }
    //move to player logic + zigzag movement
    void Update() {
        Vector3 directionToPlayer = (moveToPlayer.transform.position - transform.position).normalized;
        
        zzTimer += Time.deltaTime * zzFrequency;
        //perpendicular direction to the player
        Vector3 perpendicular = new Vector3(-directionToPlayer.y, directionToPlayer.x, 0);
        //apply zigzag effect
        Vector3 zz = perpendicular * Mathf.Sin(zzTimer) * zzAmplitude;
        //combine move to player and zigzag
        Vector3 moveDirection = directionToPlayer + zz;
        moveDirection.Normalize();
        //final zigzag+move to play movement
        transform.position += moveDirection * eMoveSpeed * Time.deltaTime;
    }
}