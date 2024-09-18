using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class mainMenu : MonoBehaviour {
    public enum mainMenuState {
        Playing = 0,
        Options = 1,
        LevelUp = 2,
        PauseScreen = 3
    }

    public mainMenuState state;

    public options optionsScript;
    public pause pauseScript;

    public GameObject Playing;
    public GameObject Options;
    public GameObject LevelUp;
    public GameObject PauseScreen;
    
    void Update() {
        switch (state) {
            case mainMenuState.Playing:
                if (Input.GetKeyDown(KeyCode.Escape)) {
                    state = mainMenuState.PauseScreen;
                } 
                return;
            case mainMenuState.Options:
                optionsState();
                return;
            case mainMenuState.LevelUp:
                return;
            case mainMenuState.PauseScreen:
                pauseState();
                return;
        }    
    }

    void optionsState() {
              
    }
    void pauseState() {
        if (pauseScript != null) {
            pauseScript.pauseState();

            if (Input.GetKeyDown(KeyCode.Escape)) {
                pauseScript.closePauseState();
                state = mainMenuState.Playing;
            }
        }
    }
}