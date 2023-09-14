using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Faca : MonoBehaviour
{
    [SerializeField] float speed;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * speed);
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "DeathZone")
        {
            Destroy(gameObject);
        }  
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
      if(collision.gameObject.tag == "DeathZone")
        {
            Destroy(gameObject);
        }  
    }
}
