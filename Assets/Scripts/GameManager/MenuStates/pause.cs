using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pause : MonoBehaviour {
    public GameObject PauseState;

    public void pauseState() {
        PauseState.SetActive(true);
        Time.timeScale = 0;
    }
    public void closePauseState() {
        PauseState.SetActive(false);
    }
    public void ExitGame() {
        Application.Quit();
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}