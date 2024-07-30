using UnityEngine;
using System.Collections;

public class LightController : MonoBehaviour
{
    public Light pointLight;

    public void IncreaseLightIntensity(float duration, float amount)
    {
        pointLight.intensity += amount;
        StartCoroutine(ResetLightIntensity(duration, amount));
    }

    public void DecreaseLightIntensity(float duration, float amount)
    {
        pointLight.intensity -= amount;
        StartCoroutine(ResetLightIntensity(duration, -amount));
    }

    private IEnumerator ResetLightIntensity(float duration, float amount)
    {
        yield return new WaitForSeconds(duration);
        pointLight.intensity -= amount;
    }
}
