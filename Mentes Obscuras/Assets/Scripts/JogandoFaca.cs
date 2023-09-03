using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JogandoFaca : MonoBehaviour

{
    public GameObject facaPrefab; //
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
       Instantiate(facaPrefab, transform.position, transform.rotation);
    }
    
}
