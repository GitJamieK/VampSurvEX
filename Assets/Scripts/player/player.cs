using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerUpdate : MonoBehaviour {
    public int maxHealth = 100;
    public int health = 100;
    public int curExp;
    public int maxExp;
    public int curLevel;
    progBar xpBar;
    public mainMenu mainMenu;
    
    void OnEnable() { //subscribe event
        ExpManager.Instance.onExpChange += handleExpChange;
    }
    void Start() {
        health = maxHealth;
        xpBar = FindObjectOfType<progBar>();
        xpBar.min = 0;
        xpBar.max = maxExp;
        xpBar.curr = curExp;
        xpBar.UpdateBar();
    }
    public void handleExpChange(int newExp) {
        curExp += newExp;
        if (curExp >= maxExp) {levelUp();}
        // add ui to show level up logic
        xpBar.curr = curExp;
        xpBar.UpdateBar();
    }
    public void levelUp() {
        /* temp?? -> */ maxHealth += 10;
        /* temp?? -> */ health = maxHealth;
        curLevel++;
        curExp = 0; //reset xp on player
        maxExp += 100; //increase xp needed for next level.
        xpBar.max = maxExp; //update progress bar max value
        xpBar.curr = curExp; //reset progress bar current XP
        xpBar.UpdateBar();
        mainMenu.state = mainMenu.mainMenuState.LevelUp;
    }
    public void takeDamage(int someDamage) {
        health -= someDamage;
        if (health<=0) Death();
    }
    void Death() {
        Debug.Log("Player has died!");
        mainMenu.state = mainMenu.mainMenuState.DeathScreen;
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