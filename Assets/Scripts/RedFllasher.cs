using UnityEngine;

public class RedFlasher : MonoBehaviour
{
    public Light redLight;
    public float flashInterval = 0.3f;
    private float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= flashInterval)
        {
            redLight.enabled = !redLight.enabled;
            timer = 0f;
        }
    }
}
