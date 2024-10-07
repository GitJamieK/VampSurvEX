using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class upgrade : MonoBehaviour {
    public string upgradeName;
    public Action applyUpgrade;
    public upgrade(string name, Action apply) {
        upgradeName = name;
        applyUpgrade = apply;
    }
}
