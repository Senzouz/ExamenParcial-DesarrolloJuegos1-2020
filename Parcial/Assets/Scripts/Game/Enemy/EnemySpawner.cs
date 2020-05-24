using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<GameObject> enemies;
    private float elapsed = 0f;

    void Start()
    {

    }
    void Update()
    {
        elapsed += Time.deltaTime;
        if (elapsed >= 2f)
        {
            elapsed = 0f;
            float x = Random.Range(-4.5f,4.5f);
            Vector2 position = new Vector2(x, transform.position.y);
            int index = Random.Range(0, enemies.Count);
            Instantiate(enemies[index], position, Quaternion.identity);
        }
    }
}

