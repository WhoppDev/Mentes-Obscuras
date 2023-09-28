using System.Collections;
using System.Collections.Generic;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class DiaeNoite : MonoBehaviour
{
    [SerializeField] private float timeSpeed;

    public Light2D globalLight2D;
    public float decreaseRate = 0.1f; // Taxa de diminuição da intensidade por segundo

    private float initialIntensity;

    private void Start()
    {
        initialIntensity = globalLight2D.intensity;
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.rotation *= Quaternion.Euler(0, 0, timeSpeed * Time.deltaTime);
        LightControl();
    }

    private void LightControl()
    {
        // Diminui a intensidade ao longo do tempo
        globalLight2D.intensity += decreaseRate * Time.deltaTime;

        // Verifica se a intensidade atingiu um valor mínimo
        if (globalLight2D.intensity >= 1f)
        {
            globalLight2D.intensity = 1f;
        }
    }


}
