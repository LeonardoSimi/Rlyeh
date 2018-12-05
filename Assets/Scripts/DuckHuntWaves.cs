using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckHuntWaves : MonoBehaviour {

    [SerializeField]
    Transform rotationCenter; //main camera

    [SerializeField]
    float rotationRadius = 0.2f;
    [SerializeField]
    float angularSpeed = 5f;

    float posX, posY, angle = 0f;

    // Update is called once per frame
    void Update()
    {
        posX = rotationCenter.position.x + Mathf.Cos(angle) * rotationRadius;
        posY = rotationCenter.position.y + Mathf.Sin(angle) * rotationRadius - 1.54f;
        transform.position = new Vector2(posX, posY);
        angle = angle + Time.deltaTime * angularSpeed;

        if (angle >= 360f)
            angle = 0f;
    }
}

