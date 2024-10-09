using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class pWeapon : MonoBehaviour {
    public Transform swordTransform;
    public playerUpdate player;
    void Update() {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 swordDirection = mousePos - (Vector2)transform.position;
        swordTransform.up = swordDirection.normalized;
    }
    //collision from child object with enemy, apply 1 damage to somePDamage in enemy
    public void OnWeaponTriggerEnter2D(Collider2D other) {
        string[] tagsToCheck = { "enemy1", "enemy2", "enemy3" };
        if (tagsToCheck.Any(tag => other.gameObject.CompareTag(tag))) {
            enemy e = other.GetComponent<enemy>();
            Debug.Log("collsion with enemy from weapon");
            StartCoroutine(e.FlashRed());
            other.GetComponent<enemy>()?.eTakeDamage(player.pDmg);
        }
    }
}