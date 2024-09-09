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
        Debug.Log("Player took"+someDamage+"damage, health remaining: "+health);
        if (health<=0) Death();
        //add 'someDamage' some damage from enemy when enemy touching player
    }
    void Death() {
        Debug.Log("Player has died!");
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D other) {
        Debug.Log("collision");
        if (other.gameObject.CompareTag("enemy1")) {
            Debug.Log("Player has taken damage, new health:"+health);
            takeDamage(2);
        }
    }
}