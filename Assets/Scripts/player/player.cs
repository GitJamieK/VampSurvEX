using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class player : MonoBehaviour {
    public const int maxHealth = 100;
    public int health = 100;
    
    void Start() {
        health = maxHealth;
    }
    void Update() {
        
    }
    public void takeDamage(int someDamage) {
        health -= someDamage;
        if (health<=0) Death();
    }
    void Death() {
        Debug.Log("Player has died!");
        Destroy(gameObject);
    }
    // Collision with enemy logic
    void OnCollisionEnter2D(Collision2D other) {
        Debug.Log("collision with enemy from player");
        if (other.gameObject.CompareTag("enemy1")) {
            Debug.Log("Player has taken damage, new health:"+health);
            enemy enemy = other.gameObject.GetComponent<enemy>();
            takeDamage(enemy.eDamage);
        }
    }
}