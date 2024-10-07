using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerWeaponSize : MonoBehaviour {
    public pWeapon pWeapon;
    public mainMenu mainMenu;
    public GameObject LevelUpState;
    public void PlayerWeaponSize() {
        Vector3 currentScale = pWeapon.swordTransform.localScale;
        pWeapon.swordTransform.localScale = currentScale * 1.1f;

        LevelUpState.SetActive(false);
        mainMenu.state = mainMenu.mainMenuState.Playing;
    }
}
