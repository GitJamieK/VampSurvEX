using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pWeapon : MonoBehaviour {
    public Transform swordTransform;
    void Start() {
        
    }
    void Update() {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 swordDirection = mousePos - (Vector2)transform.position;
        swordTransform.up = swordDirection.normalized;
    }
    //collision with enemy, -1 hp
    void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("enemy1")) {
            Debug.Log("collsion with enemy from weapon");
            other.GetComponent<enemy>()?.eTakeDamage(1);
        }
    }
}
