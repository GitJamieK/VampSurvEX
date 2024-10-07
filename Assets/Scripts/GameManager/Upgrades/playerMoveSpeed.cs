using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMoveSpeed : MonoBehaviour {
    public playerMovement playerMovement;
    public mainMenu mainMenu;
    public GameObject LevelUpState;
    public void PlayerMoveSpeed() {
        playerMovement.moveSpeed += 0.5f;

        LevelUpState.SetActive(false);
        mainMenu.state = mainMenu.mainMenuState.Playing;
    }
}
