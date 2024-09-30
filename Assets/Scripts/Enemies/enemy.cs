using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class enemy : MonoBehaviour {
    public int eMaxHealth = 5;
    public int eHealth = 5;
    public int eDamage = 5;
    public bool hasIncreasedStats = false;
    public int expAmount = 50;

    public GameObject Blood;
    public SpriteRenderer sprite;

    public UnityEvent<enemy> onKilled;

    void Start() {
        eHealth = eMaxHealth;
        if (gameObject.CompareTag("enemy2")) {eHealth = eMaxHealth += 3;} //Debug.Log("hit enemy2 "+eHealth);}
    }
    public IEnumerator FlashRed() {
        if (sprite != null) {
            sprite.color = Color.red;
            yield return new WaitForSeconds(0.1f);
        } if (sprite != null) {sprite.color = Color.white;}
    }
    public void eTakeDamage(int somePDamage) {
        eHealth -= somePDamage;
        if (eHealth<=0) eDeath();
    }
    public void eDeath() {
        onKilled?.Invoke(this);
        Instantiate(Blood, transform.position, Quaternion.identity);
    }
}