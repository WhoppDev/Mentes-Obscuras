using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LancadorDeBalao : MonoBehaviour
{
     public GameObject balaoPrefab; //
    public Transform shootPoint; 
    public float shootInterval = 2f; 

    private Queue<GameObject> miniObjectQueue = new Queue<GameObject>();
    private float lastShootTime;

    private void Update()
    {
        if (Time.time - lastShootTime >= shootInterval)
        {
            Shoot();
            lastShootTime = Time.time;
        }
    }

    void Shoot()
    {
       Instantiate(balaoPrefab, transform.position, transform.rotation);
    }
}
