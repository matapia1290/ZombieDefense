using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    public Transform[] zombieSpawner;
    public GameObject zombiePrefab;
    public int maxZombie = 0;
    public float zombieTimerLimit = 30f;
    public float nextRoundTimer = 0f;
    void Start()
    {
        for(int i = 0; i < maxZombie; i++) 
        {
            GameObject newZombie = Instantiate(zombiePrefab, zombieSpawner[Random.Range(0, zombieSpawner.Length)].position,Quaternion.identity);
        }
    }
    void Update()
    {
        nextRoundTimer += Time.deltaTime;
        if(nextRoundTimer > zombieTimerLimit) 
        {
            nextRoundTimer = 0;
            for (int i = 0; i < maxZombie; i++)
            {
                GameObject newZombie = Instantiate(zombiePrefab, zombieSpawner[i].position, Quaternion.identity);
            }

            if (zombieTimerLimit != 10f) 
            {
                zombieTimerLimit -= 5f;
            }
        }
    }
}
