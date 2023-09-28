using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiaeNoite : MonoBehaviour
{
    [SerializeField] private float timeSpeed;


    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.rotation *= Quaternion.Euler(0, 0, timeSpeed * Time.deltaTime);
    }
}
