using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class ZombieMovement : MonoBehaviour
{
    public NavMeshAgent zombie;
    public Transform zombPos;
   
    public int hit = 0;
   // public Transform player;
    void Start()
    {
        zombie = GetComponent<NavMeshAgent>();
       
    }

    // Update is called once per frame
    void Update()
    {
        zombie.SetDestination(GameObject.FindWithTag("Player").transform.position);

        if (hit == 3) 
        {
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
