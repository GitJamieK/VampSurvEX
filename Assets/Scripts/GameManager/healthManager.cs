using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthManager : MonoBehaviour {
    public playerUpdate player;
    public Image healthBar;
    void Start() {
        if (player == null) {
            player = FindObjectOfType<playerUpdate>();
        }
        updateHealthBar();
    }
    public void updateHealthBar() {
        healthBar.fillAmount = (float)player.health / player.maxHealth;
    }
}