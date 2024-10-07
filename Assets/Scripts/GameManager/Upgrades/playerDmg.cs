using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class playerDmg : MonoBehaviour {
    public playerUpdate player;
    public mainMenu mainMenu;
    public GameObject LevelUpState;
    public void PlayerDmg() {
        player.pDmg += 1;

        LevelUpState.SetActive(false);
        mainMenu.state = mainMenu.mainMenuState.Playing;
    }
}
