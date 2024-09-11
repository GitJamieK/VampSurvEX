using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponChildCollider : MonoBehaviour {
    private pWeapon parentWeaponScript;
    void Start() {
        parentWeaponScript = GetComponentInParent<pWeapon>();
    }
    void OnTriggerEnter2D(Collider2D other) {
        parentWeaponScript.OnWeaponTriggerEnter2D(other);
    }
}
