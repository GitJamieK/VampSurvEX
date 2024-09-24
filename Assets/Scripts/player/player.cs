using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerUpdate : MonoBehaviour {
    public int maxHealth = 100;
    public int health = 100;
    [SerializeField] public int curExp;
    [SerializeField] public int maxExp;
    [SerializeField] public int curLevel;
    progBar xpBar;
    
    void OnEnable() { //subscribe event
        ExpManager.Instance.onExpChange += handleExpChange;
    }
    void Start() {
        health = maxHealth;
        xpBar = FindObjectOfType<progBar>(); // Find the progress bar in the scene
        xpBar.min = 0; // Set the min value to 0 for XP
        xpBar.max = maxExp; // Set the max value for the progress bar
        xpBar.curr = curExp; // Set the current XP
        xpBar.UpdateBar(); // Initialize the progress bar display
    }
    public void handleExpChange(int newExp) {
        curExp += newExp;
        if (curExp >= maxExp) {levelUp();}
        // add ui to show level up logic
        xpBar.curr = curExp;
        xpBar.UpdateBar();
    }
    void levelUp() {
        /* temp?? -> */ maxHealth += 10;
        /* temp?? -> */ health = maxHealth;
        curLevel++;
        curExp = 0; //reset xp on player
        maxExp += 100; //increase xp needed for next level.
        xpBar.max = maxExp; // Update the progress bar's max value
        xpBar.curr = curExp; // Reset progress bar's current XP
        xpBar.UpdateBar(); // Update the progress bar
    }
    public void takeDamage(int someDamage) {
        health -= someDamage;
        if (health<=0) Death();
    }
    void Death() {
        Debug.Log("Player has died!");
        SceneManager.LoadScene("StartScreen"); //make death ui logic 
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
    void OnDisable() { //unsubscribe from event
        ExpManager.Instance.onExpChange -= handleExpChange;
    }
}