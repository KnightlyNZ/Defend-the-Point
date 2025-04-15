using UnityEngine;
using TMPro;

public class WaveTextFlasher : MonoBehaviour
{
    public TextMeshProUGUI waveText;
    public float flashSpeed = 1f;

    private bool isRed = true;
    private float timer = 0f;

    void Start()
    {
        if (waveText == null)
            waveText = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 1f / flashSpeed)
        {
            waveText.color = isRed ? Color.blue : Color.red;
            isRed = !isRed;
            timer = 0f;
        }
    }
}
