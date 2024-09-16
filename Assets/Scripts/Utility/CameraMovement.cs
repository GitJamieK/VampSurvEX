using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {
    public float moveSpeed = 1f;
    public Vector2 pointA;
    public Vector2 pointB;

    private float t = 0f;

    void Update() {
        t += Time.deltaTime*moveSpeed;

        float sinValue = Mathf.Sin(t)*0.5f+0.5f; //setting Mathf.Sin to 0 and 1 instead -1 and 1

        Vector3 newPosition = Vector3.Lerp(pointA, pointB, sinValue);
        transform.position = new Vector3(newPosition.x, newPosition.y, transform.position.z);
    }
}