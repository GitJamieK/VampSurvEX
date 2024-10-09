using System;
using UnityEditor;
using UnityEngine;
using UnityEditorInternal;

public class EnemyCreator : EditorWindow {
    string enemyName = "";
    string[] tags;
    int selectedTagIndex = 0;
    MonoScript script1, script2;
    GameObject enemyPrefab;
    Sprite enemySprite;
    GameObject bloodPrefab;

    [MenuItem("Tools/EnemyCreator")]
    public static void showWindow() {
        GetWindow<EnemyCreator>("Enemy Creator");
    }

    public void OnEnable() {
        tags = UnityEditorInternal.InternalEditorUtility.tags;
    }

    public void OnGUI() {
        GUILayout.Label("Create New Enemy Prefab", EditorStyles.boldLabel);

        GUILayout.Label("Enemy Name:");
        enemyName = GUILayout.TextField(enemyName);

        GUILayout.Space(10);

        GUILayout.Label("Assign Tag:");
        selectedTagIndex = EditorGUILayout.Popup(selectedTagIndex, tags);

        if (GUILayout.Button("Create New Tag")) { CreateTagWindow.ShowWindow(this); }

        GUILayout.Space(10);

        GUILayout.Label("Assign Sprite", EditorStyles.boldLabel);
        enemySprite = (Sprite)EditorGUILayout.ObjectField("Enemy Spite", enemySprite, typeof(Sprite), false);

        GUILayout.Space(10);

        GUILayout.Label("Assign Scripts", EditorStyles.boldLabel);
        script1 = (MonoScript)EditorGUILayout.ObjectField("enemy.cs", script1, typeof(MonoScript), false);
        script2 = (MonoScript)EditorGUILayout.ObjectField("enemyMovement.cs", script2, typeof(MonoScript), false);

        if (GUILayout.Button("Create Enemy")) { CreateEnemyPrefab(); }
    }

    void CreateEnemyPrefab() {
        if (string.IsNullOrEmpty(enemyName))
        {
            EditorUtility.DisplayDialog("Error", "Please enter a valid enemy name.", "OK");
            return;
        }

        GameObject enemy = new GameObject(enemyName);

        enemy.tag = tags[selectedTagIndex];

        Rigidbody2D rb = enemy.AddComponent<Rigidbody2D>();
        rb.gravityScale = 0;

        BoxCollider2D boxCollider = enemy.AddComponent<BoxCollider2D>();

        if (enemySprite != null) {
            GameObject spriteObject = new GameObject("Sprite");
            spriteObject.transform.SetParent(enemy.transform);
            SpriteRenderer spriteRenderer = spriteObject.AddComponent<SpriteRenderer>();
            spriteRenderer.sprite = enemySprite;

            spriteObject.transform.localRotation = Quaternion.Euler(0, 0, -45);
        }

        if (script1 != null) {
            enemy.AddComponent(script1.GetClass());
        }

        if (script2 != null) {
            enemy.AddComponent(script2.GetClass());
        }

        enemy enemyScript = enemy.AddComponent<enemy>();
        if (bloodPrefab != null) {
            enemyScript.Blood = bloodPrefab;
        }

        string localPath = "assets/Prefabs/" + enemyName + ".prefab";
        PrefabUtility.SaveAsPrefabAsset(enemy, localPath);
        DestroyImmediate(enemy);

        EditorUtility.DisplayDialog("Success", "Enemy prefab created!", "OK");
    }

    public class CreateTagWindow : EditorWindow {
        string newTag = "";
        EnemyCreator parentWindow;

        public static void ShowWindow(EnemyCreator parent) {
            CreateTagWindow window = GetWindow<CreateTagWindow>("Create New Tag", true);
            window.minSize = new Vector2(300, 150);
            window.parentWindow = parent;
            window.Show();
        }

        void OnGUI() {
            GUILayout.Label("Enter new tag name:", EditorStyles.boldLabel);
            newTag = GUILayout.TextField(newTag);

            if (GUILayout.Button("Create")) {
                if (!string.IsNullOrEmpty(newTag) && !System.Array.Exists(InternalEditorUtility.tags, tag => tag == newTag)) {
                    SerializedObject tagManager = new SerializedObject(AssetDatabase.LoadAllAssetsAtPath("ProjectSettings/TagManager.asset")[0]);
                    SerializedProperty tagsProp = tagManager.FindProperty("tags");
                    tagsProp.InsertArrayElementAtIndex(tagsProp.arraySize);
                    tagsProp.GetArrayElementAtIndex(tagsProp.arraySize - 1).stringValue = newTag;
                    tagManager.ApplyModifiedProperties();
                    Debug.Log($"Tag '{newTag}' created.");
                    parentWindow.OnEnable();
                }
            }

            if (GUILayout.Button("Cancel")) {
                this.Close();
            }
        }
    }
}