using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode()]
public class progBar : MonoBehaviour {
    public int min;
    public int max;
    public int curr;
    public Image mask;

    void Start() { //subscribe event
        if (ExpManager.Instance != null) {
            ExpManager.Instance.onExpChange += handleExpChange;
        }
        if (mask != null) {UpdateBar();}
    }
    public void UpdateBar() {
        float curOffset = curr - min;
        float maxOffset = max - min;
        mask.fillAmount = curOffset / maxOffset;
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