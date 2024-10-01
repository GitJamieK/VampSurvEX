using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelUp : MonoBehaviour {
    //public playerUpdate p;
    public GameObject LevelUpState;
    public mainMenu mainMenu;
    public void levelUpState() {
        LevelUpState.SetActive(true);
    }
    public void skipLevelUp() {
        LevelUpState.SetActive(false);
        mainMenu.state = mainMenu.mainMenuState.Playing;
    }
}