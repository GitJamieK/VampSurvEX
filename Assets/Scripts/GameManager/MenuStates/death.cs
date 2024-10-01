using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.SceneManagement;

public class death : MonoBehaviour {
    public GameObject DeathState;
    public void deathState() {
        DeathState.SetActive(true);
        Time.timeScale = 0;
    }
    public void tryAgain() {
        DeathState.SetActive(false);
        SceneManager.LoadScene("MainGame");
    }
    //public void mainMenu() {
    //    SceneManager.LoadScene("StartScreen");
    //}
    public void exitGame() {
        Application.Quit();
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}