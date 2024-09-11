using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pWeapon : MonoBehaviour {
    public Transform swordTransform;
    public float minDistance = 1.4f;
    void Update() {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 swordDirection = mousePos - (Vector2)transform.position;
        if(swordDirection.magnitude>minDistance) {
            swordTransform.up = swordDirection.normalized;
        }
    }
    //collision with enemy, apply 1 damage to somePDamage in enemy
    void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("enemy1")) {
            Debug.Log("collsion with enemy from weapon");
            other.GetComponent<enemy>()?.eTakeDamage(1);
        }
    }
}