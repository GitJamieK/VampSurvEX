using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMaxHealth : MonoBehaviour {
    public playerUpdate player;
    public mainMenu mainMenu;
    public GameObject LevelUpState;
    public void PlayerMaxHealth() {
        player.maxHealth += 50;

        LevelUpState.SetActive(false);
        mainMenu.state = mainMenu.mainMenuState.Playing;
    }
}
