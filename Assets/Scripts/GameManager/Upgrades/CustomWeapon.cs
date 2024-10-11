using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CustomWeapon : MonoBehaviour {
    public mainMenu mainMenu;
    public GameObject LevelUpState;
    public GameObject weaponPrefab;
    public Button cWButton;

    public void applyCWeapon() {
        if (weaponPrefab != null) {
            GameObject weaponInstance = Instantiate(weaponPrefab);
            Transform weaponParent = GameObject.Find("++++Player++++/++++playerWeapon++++/Sword/weaponParent").transform;
            Debug.Log("Found weaponParent");
            if (weaponParent != null) {
                weaponInstance.transform.SetParent(weaponParent);
                weaponInstance.transform.localPosition = new Vector3(0f, -1.36f, 0);
                weaponInstance.transform.localRotation = Quaternion.Euler(0, 0, 135);
                Debug.Log("Weapon applied to player: " + weaponPrefab.name);
            } else {
                Debug.LogError("custom weapon not set");
            }
        } else {
            Debug.LogError("Weapon prefab is not assigned.");
        }
        
        LevelUpState.SetActive(false);
        mainMenu.state = mainMenu.mainMenuState.Playing;
        cWButton.gameObject.SetActive(false);
    }
}