using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class levelUp : MonoBehaviour {
    public GameObject LevelUpState;
    public mainMenu mainMenu;
    
    public void levelUpState() {
        LevelUpState.SetActive(true);
        mainMenu.state = mainMenu.mainMenuState.LevelUp;
        //set all anim in children to UnsaledTime
        Animator[] animators = LevelUpState.GetComponentsInChildren<Animator>();
        foreach (Animator animator in animators) {
            animator.updateMode = AnimatorUpdateMode.UnscaledTime;
        }
    }
    public void skipLevelUp() {
        LevelUpState.SetActive(false);
        mainMenu.state = mainMenu.mainMenuState.Playing;
    }
}