using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JogandoFaca : MonoBehaviour
{
    public GameObject miniObjectPrefab; 
    public float shootInterval = 2f; 

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
        GameObject miniObject = Instantiate(miniObjectPrefab, transform.position, transform.rotation);
        Rigidbody rb = miniObject.GetComponent<Rigidbody>();
        
        
        rb.velocity = transform.forward * 10f;
    }
}

