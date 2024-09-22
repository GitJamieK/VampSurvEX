using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerUpdate : MonoBehaviour {
    public const int maxHealth = 100;
    public int health = 100;
    
    void Start() {
        health = maxHealth;
    }
    public void takeDamage(int someDamage) {
        health -= someDamage;
        if (health<=0) Death();
    }
    void Death() {
        Debug.Log("Player has died!");
        SceneManager.LoadScene("StartScreen");
    }
    //Collision with enemy logic
    void OnCollisionEnter2D(Collision2D other) {
        Debug.Log("collision with enemy from player");
        if (other.gameObject.CompareTag("enemy1") || other.gameObject.CompareTag("enemy2")) {
            Debug.Log("Player has taken damage, new health:"+health);
            enemy enemy = other.gameObject.GetComponent<enemy>();
            takeDamage(enemy.eDamage);
        }
    }
}