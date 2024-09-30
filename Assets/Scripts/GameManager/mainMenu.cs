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
        PauseScreen = 3,
        DeathScreen = 4
    }

    [SerializeField] enemyManager myenemyManager;
    [SerializeField] playerUpdate myplayer;

    public mainMenuState state;

    public options optionsScript;
    public pause pauseScript;
    public death deathScript;

    public GameObject Playing;
    public GameObject Options;
    public GameObject LevelUp;
    public GameObject PauseScreen;
    public GameObject DeathScreen;
    
    void Update() {
        switch (state) {
            case mainMenuState.Playing:
                myenemyManager.enemyUpdate();
                if (Time.timeScale == 0) {Time.timeScale = 1;}
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
            case mainMenuState.DeathScreen:
                deathState();
                return;
            default:
                Debug.Log("[No Gamestate - " + state + "]");
                break;
        }    
    }
    private void playerUpdate()
    {
        throw new NotImplementedException();
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
    void deathState() {
        if (deathScript != null) {
            deathScript.deathState();
        }
    }
}