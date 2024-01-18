using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PointCounter : MonoBehaviour
{
    public List<GameObject> zombies = new List<GameObject>();
    public int points = 0;
    public Text pointCounter;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        pointCounter.text = "Points: " + points;
        for(int i = 0; i < zombies.Count; i++) 
        {
            if(zombies[i] == null) 
            {
                points++;
                zombies.Remove(zombies[i]);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
       if(other.tag == "Zombie") 
       {
            zombies.Add(other.gameObject);
       }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Zombie")
        {
            zombies.Remove(other.gameObject);
        }
    }
}
