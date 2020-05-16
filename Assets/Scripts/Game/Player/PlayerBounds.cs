using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBounds : MonoBehaviour
{

        private float minX = -4.5f;
        private float maxX = 4.5f;

    void Update()
    {
        if (transform.position.x < minX)
        {
            Vector2 temp = transform.position;
            temp.x = minX;
            transform.position = temp;
        }
        else if (transform.position.x > maxX)
        {
            Vector2 temp = transform.position;
            temp.x = maxX;
            transform.position = temp;
        }
    }
}
