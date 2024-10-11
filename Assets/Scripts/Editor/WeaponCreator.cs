using System;
using UnityEditor;
using UnityEngine;

public class WeaponCreator : EditorWindow {
    string weaponName = "New Mirrored Sword";
    float weaponSize = 1.0f;
    Sprite weaponSprite;
    MonoScript script1;
    public GameObject weaponPrefab;

    [MenuItem("Tools/Weapon Creator")]
    public static void showWindow() {
        GetWindow<WeaponCreator>("WeaponCreator");
    }

    void OnGUI() {
        GUILayout.Label("Create Mirrored Weapon", EditorStyles.boldLabel);

        weaponName = EditorGUILayout.TextField("Weapon Name:", weaponName);

        GUILayout.Space(10);

        weaponSize = EditorGUILayout.Slider("Weapon Size", weaponSize, 1f, 1.5f);

        GUILayout.Space(10);

        weaponSprite = (Sprite)EditorGUILayout.ObjectField("Weapon Sprite:", weaponSprite, typeof(Sprite), false);

        GUILayout.Space(10);

        GUILayout.Label("Assign Scripts", EditorStyles.boldLabel);
        script1 = (MonoScript)EditorGUILayout.ObjectField("weaponChildCollider.cs:", script1, typeof(MonoScript), false);

        GUILayout.Label("Pleace prefab on\nUpgrades -> CustomWeapon -> Weapon Prefab.");

        if (GUILayout.Button("Create Mirrored Weapon")) { CreateMirroredWeapon(); }
    }

    void CreateMirroredWeapon() {
        if (string.IsNullOrEmpty(weaponName))
        {
            EditorUtility.DisplayDialog("Error", "Please enter a valid enemy name.", "OK");
            return;
        }

        GameObject mirroredWeapon = new GameObject(weaponName);

        SpriteRenderer spriteRenderer = mirroredWeapon.AddComponent<SpriteRenderer>();
        spriteRenderer.sprite = weaponSprite;

        Rigidbody2D rb = mirroredWeapon.AddComponent<Rigidbody2D>();
        rb.gravityScale = 0;

        BoxCollider2D boxCollider = mirroredWeapon.AddComponent<BoxCollider2D>();
        boxCollider.isTrigger = true;

        mirroredWeapon.transform.localScale = new Vector3(weaponSize, weaponSize, 1);

        if (script1 != null) {
            mirroredWeapon.AddComponent(script1.GetClass());
        }

        String localPath = "Assets/Prefabs/" + weaponName + ".prefab";
        PrefabUtility.SaveAsPrefabAsset(mirroredWeapon, localPath);
        DestroyImmediate(mirroredWeapon);

        Debug.Log($"Mirrored weapon '{weaponName}' created at {localPath}");
    }
}