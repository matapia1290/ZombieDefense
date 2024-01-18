using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretMovement : MonoBehaviour
{
    public GameObject turretBody;
    public GameObject turretBarrel;
    public List<GameObject> zombies = new List<GameObject>();



    public Transform bulletPos;
    public GameObject bulletPrefab;
    public float bulletSpeed = 0;
    public float bulletTimer = 0;



    
    public float coneAngle = 45f;
    public float reset = 0;
    



    public float turnSpeed = 0f;
    private float rotateDegrees = 0f;
    public float turretAngleFixed = 10f;
    private bool turnR = true;
    public bool scanning = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(zombies.Count > 0) 
        {
            ShootEnemy();
        }
    

        if (scanning)
        {
            BodyMovement();
        }
        reset += Time.deltaTime;

        if (reset > 5 && scanning == false)
        {
            reset = 0;
            scanning = true;
        }




    }
    void BodyMovement()
    {
        if (scanning)
        {
            if (turnR)
            {
                rotateDegrees += turnSpeed * Time.fixedDeltaTime;
                turretBody.transform.localRotation = Quaternion.Euler(0, rotateDegrees, 0);

                if (rotateDegrees >= turretAngleFixed)
                {
                    turnR = false;
                }

            }
            else if (!turnR)
            {
                rotateDegrees -= turnSpeed * Time.fixedDeltaTime;
                turretBody.transform.localRotation = Quaternion.Euler(0, rotateDegrees, 0);

                if (rotateDegrees <= -turretAngleFixed)
                {
                    turnR = true;
                }

            }

        }
    }
    void ShootEnemy()
    {
        
        
        for (int i = 0; i < zombies.Count; i++) 
        {
            if (zombies[i] == null) 
            {
                zombies.Remove(zombies[i]);
                scanning = true;
            }
            else 
            {
                scanning = false;
                turretBody.transform.LookAt(zombies[i].transform);
                bulletTimer += Time.deltaTime;
                if (bulletTimer > 7f)
                {
                    GameObject newBullet = Instantiate(bulletPrefab, bulletPos.position, bulletPos.rotation);
                    Rigidbody rb = newBullet.GetComponent<Rigidbody>();
                    if (rb != null)
                    {
                        rb.velocity = bulletPos.forward * bulletSpeed;
                    }

                    bulletTimer = 0;
                }
            }
                
        }
    }

  
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Zombie") 
        {
            zombies.Add(other.gameObject);
        }
    }
}
