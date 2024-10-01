using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode()]
public class progBar : MonoBehaviour {
    public int min;
    public int max;
    public int curr;
    public Image mask;
    public TextMeshProUGUI lvlText;
    public playerUpdate p;

    void Start() { //subscribe event
        if (ExpManager.Instance != null) {
            ExpManager.Instance.onExpChange += handleExpChange;
        }
        if (mask != null) {UpdateBar();}
        updateLvlText();
    }
    public void UpdateBar() {
        float curOffset = curr - min;
        float maxOffset = max - min;
        mask.fillAmount = curOffset / maxOffset;
        updateLvlText();
    }
    public void updateLvlText() {
        if (lvlText != null && p != null) { lvlText.text = "lvl: "+p.curLevel.ToString(); }
    }
    void handleExpChange(int amount) {
        curr += amount; // Update current XP
        UpdateBar();
    }
    void OnDisable() { //unsubscribe from event
        if (ExpManager.Instance != null) {
            ExpManager.Instance.onExpChange -= handleExpChange;
        }
    }
}