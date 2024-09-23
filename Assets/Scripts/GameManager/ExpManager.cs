using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpManager : MonoBehaviour {
    public static ExpManager Instance; // Singleton

    public delegate void expChangeManager(int amount);
    public event expChangeManager onExpChange;

    // Singleton Check
    void Awake() {
        if (Instance != null && Instance != this) {
            Destroy(this);
        } else {
            Instance = this;
        }
    }

    public void addExp(int amount) {
        onExpChange?.Invoke(amount);
    }
}