using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class upgradeManager : MonoBehaviour {
    public playerUpdate player;
    public playerMovement playerMovement;
    public pWeapon pWeapon;
    public GameObject upgradeUI;
    public Button[] upgrButtons;
    public applyUpgrade applyUpgrade;
    public mainMenu mainMenu;

    List<upgrade> availableUpgrades = new List<upgrade>();

    void Start() {
        availableUpgrades.Add(new upgrade("+1 Damage", () => player.pDmg += 1));
        availableUpgrades.Add(new upgrade("Increase Weapon Size", () => {
            Vector3 currentScale = pWeapon.swordTransform.localScale;
            pWeapon.swordTransform.localScale = currentScale * 1.1f;
        }));
        availableUpgrades.Add(new upgrade("+50 Max HP", () => player.maxHealth += 50));
        availableUpgrades.Add(new upgrade("Increase Movement Speed", () => playerMovement.moveSpeed += 0.5f));
    }

    IEnumerator showUpgradesCoroutine() {
        List<upgrade> chosenUpgrades = pickRandomUpgrades(2);
        int maxUpgradeToShow = Mathf.Min(chosenUpgrades.Count, upgrButtons.Length);

        for (int i = 0; i < maxUpgradeToShow; i++) {
            upgrButtons[i].GetComponentInChildren<Text>().text = chosenUpgrades[i].upgradeName;
            int index = i;
            upgrButtons[i].onClick.RemoveAllListeners();
            upgrButtons[i].onClick.AddListener(() => applyUpgrade.ApplyUpgrade(chosenUpgrades[index]));
            upgrButtons[i].gameObject.SetActive(true);
            Debug.Log("IEnumerator success xdddd");
        }
        
        for (int i = maxUpgradeToShow; i < upgrButtons.Length; i++) {
            upgrButtons[i].gameObject.SetActive(false);
        }
        yield break;
    }
    
    public void showUpgrades() {
        StartCoroutine(showUpgradesCoroutine());
        mainMenu.state = mainMenu.mainMenuState.LevelUp;
    }
    

    List<upgrade> pickRandomUpgrades(int count) {
        List<upgrade> selectedUpgrades = new List<upgrade>();
        HashSet<int> usedIndices = new HashSet<int>();//avoid duplicates

        while (selectedUpgrades.Count < count) {
            if (availableUpgrades.Count == 0) {
                Debug.LogWarning("No upgrades available");
                break;
            }

            int randomIndex = Random.Range(0, availableUpgrades.Count);

            //if this upgrade hasn't been selected yet, add it
            if (!usedIndices.Contains(randomIndex)) {
                selectedUpgrades.Add(availableUpgrades[randomIndex]);
                usedIndices.Add(randomIndex);
            }
            
            //avoid infinite loop
            if (selectedUpgrades.Count == availableUpgrades.Count) {
                break; // If we've picked all unique upgrades, stop.
            }
        }

        return selectedUpgrades;
    }
}