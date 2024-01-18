using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    public Transform[] zombieSpawner;
    public GameObject zombiePrefab;
    public float zombieTimerLimit = 60f;
    public float nextRoundTimer = 0f;
    void Start()
    {
        for(int i = 0; i < zombieSpawner.Length; i++) 
        {
            if(zombieSpawner[i] != null) 
            {
               GameObject newZombie = Instantiate(zombiePrefab, zombieSpawner[i].position,Quaternion.identity);
            }
           
        }
    }
    void Update()
    {
        nextRoundTimer += Time.deltaTime;
        if(nextRoundTimer > zombieTimerLimit) 
        {
            nextRoundTimer = 0;
            for (int i = 0; i < zombieSpawner.Length; i++)
            {
                if (zombieSpawner[i] != null)
                {
                    GameObject newZombie = Instantiate(zombiePrefab, zombieSpawner[i].position, Quaternion.identity);
                } 
            }
        }
    }
}
