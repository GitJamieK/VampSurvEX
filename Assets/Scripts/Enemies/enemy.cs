using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class enemy : MonoBehaviour {
    public const int eMaxHealth = 5;
    public int eHealth = 5;
    public int eDamage = 5;

    public UnityEvent<enemy> onKilled;

    void Start() {
        eHealth = eMaxHealth;
    }
    public void updateEnemy() {
        
    }
    public void eTakeDamage(int somePDamage) {
        eHealth -= somePDamage;
        if (eHealth<=0) eDeath();
    }
    public void eDeath() {
        //Debug.Log("Enemy has died!");
        onKilled?.Invoke(this);
        //Destroy(gameObject);
    }
}