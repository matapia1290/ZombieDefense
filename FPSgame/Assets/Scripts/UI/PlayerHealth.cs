using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Text healthText;
    public int health = 100;
    public float zombieTimer = 0f;
    public float exitTimer = 0f;
    public bool zombieAttacked = false;
   
    

    void Update()
    {
        healthText.text = "Health: " + health;

        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Zombie")
        {
             zombieAttacked = true;
             zombieTimer += Time.deltaTime;
             if (zombieTimer > .2f)
             {
                 health -= 10;//Random.Range(0, 10);
                 zombieTimer = 0;
             }
        }

       if(other.tag == "HealthPack" && health <= 90) 
       {
            health += 10;
       }
    }

    

}
