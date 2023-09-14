using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirandoJogador : MonoBehaviour
{
    public GameObject facaPrefab; 
    public Transform shootPoint; 
    public float shootInterval = 2f; 
    public float rotationSpeed = 2f; 

    public GameObject player; 
    private float lastShootTime;
    private Queue<GameObject> miniObjectQueue = new Queue<GameObject>();


     void Update()
    {
        if (Time.time - lastShootTime >= shootInterval)
        {
            Shoot();
            lastShootTime = Time.time;
        }

        
        if (player != null)
        {
            Vector3 direction = player.transform.position - transform.position;
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }

    void Shoot()
    {
        if (facaPrefab != null)
        {
            Instantiate(facaPrefab, transform.position, transform.rotation);
        }
    }

    
     void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player = other.gameObject;
        }
    }

   
     void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player = null;
        }
    }
}
