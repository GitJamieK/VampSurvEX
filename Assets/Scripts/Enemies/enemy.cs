using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour {
    public const int eMaxHealth = 5;
    public int eHealth = 5;
    public int eDamage = 2;

    void Start() {
        eHealth = eMaxHealth;
    }
    void Update() {
        
    }
    public void eTakeDamage(int somePDamage) {
        eHealth -= somePDamage;
        if (eHealth<=0) eDeath();
        //add 'somePDamage' some player damage to enemy
    }
    void eDeath() {
        Debug.Log("Enemy has died!");
        Destroy(gameObject);
    }
}