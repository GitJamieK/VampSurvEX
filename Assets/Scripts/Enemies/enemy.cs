using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour {
    public const int eMaxHealth = 5;
    public int eHealth = 5;
    public int eDamage = 5;

    void Start() {
        eHealth = eMaxHealth;
    }
    public void eTakeDamage(int somePDamage) {
        eHealth -= somePDamage;
        if (eHealth<=0) eDeath();
    }
    void eDeath() {
        Debug.Log("Enemy has died!");
        Destroy(gameObject);
    }
}