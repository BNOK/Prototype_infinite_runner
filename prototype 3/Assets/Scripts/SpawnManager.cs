using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public int spawnRate = 1;
    public float startTime = 1;

    private CharacterController player;

    public GameObject obstacle;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObstacle", startTime, spawnRate);
        player = GameObject.Find("Player").GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnObstacle()
    {
        if (player.gameOver == false)
        {
            Instantiate(obstacle, transform, false);
        }
    }
}
