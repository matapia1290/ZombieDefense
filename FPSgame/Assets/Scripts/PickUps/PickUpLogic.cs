using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpLogic : MonoBehaviour
{

    void Update()
    {
        Destroy(gameObject, 30f);    
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") 
        {
            Destroy(gameObject);
        }
    }
}
