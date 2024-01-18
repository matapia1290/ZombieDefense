using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieMovement : MonoBehaviour
{
    public NavMeshAgent zombie;
    public Transform zombPos;
    public GameObject healthPack;
    private int hit = 0;
    private int health = 3;
    public int dropNumber;
    void Start()
    {
        zombie = GetComponent<NavMeshAgent>();
        dropNumber = Random.Range(0,10);
       
    }

    void Update()
    {
        zombie.SetDestination(GameObject.FindWithTag("Player").transform.position);
        if (hit == health) 
        {
            if (dropNumber == 7) 
            {
                GameObject newHealthPack = Instantiate(healthPack, zombie.transform.position + Vector3.up * 2, Quaternion.identity);
                Debug.Log("Dropped");
            }
            
            Destroy(gameObject);
        }
        
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Bullet" || collider.tag == "Turret Bullet")
        {
            hit += 1;
        }

       

        
    }
}
