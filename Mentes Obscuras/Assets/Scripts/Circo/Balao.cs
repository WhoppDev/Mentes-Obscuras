using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balao : MonoBehaviour
{
    
   [SerializeField] float speed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * speed);
        
    }

     void OnTriggerEnter2D(Collider2D collision)
    {
      if(collision.gameObject.tag == "DeathZone")
        {
            Destroy(this.gameObject);
        
        }  
    }


    
   

}
