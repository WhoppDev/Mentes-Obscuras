using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightController : MonoBehaviour
{
    public Light2D globalLight2D;
    public float oscillationSpeed = 1.0f; // Velocidade da oscilação
    public float oscillationRange = 0.5f; // Amplitude da oscilação

    private float originalIntensity;

    // Start is called before the first frame update
    void Start()
    {
        originalIntensity = globalLight2D.intensity;
    }

    // Update is called once per frame
    void Update()
    {
        OscillateLight();
    }

    void OscillateLight()
    {
        float oscillation = Mathf.Sin(Time.time * oscillationSpeed) * oscillationRange;
        globalLight2D.intensity = originalIntensity + oscillation;
    }
}
