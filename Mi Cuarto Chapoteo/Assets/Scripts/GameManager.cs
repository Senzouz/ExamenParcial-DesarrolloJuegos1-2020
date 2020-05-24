using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] GameObject player;
    [SerializeField] GameObject platform;

    private float minX = -2.5f, maxX = 2.5f, minY = -1.7f, maxY = 1.7f;

    private bool lerpCamera;
    private float lerpTime;
    private float lerpX;

    // lerp: tween de phaser

    private void Awake()
    {
        MakeInstance();
        CreateInitialPlatforms();
    }

    void MakeInstance()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    void CreateInitialPlatforms()
    {
        Vector3 temp = new Vector3(Random.Range(minX, minX + 1.2f), Random.Range(minY, maxY), 0);
        Instantiate(platform, temp, Quaternion.identity);
        temp.y += 2f;
        Instantiate(player, temp, Quaternion.identity);

        temp = new Vector3(Random.Range(maxX, maxX - 1.2f), Random.Range(minY, maxY), 0);
        Instantiate(platform, temp, Quaternion.identity);
    }
    private void Start()
    {
        
    }

    private void Update()
    {
        
    }
}
