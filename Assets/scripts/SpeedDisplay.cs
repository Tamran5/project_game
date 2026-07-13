using UnityEngine;
using TMPro;

public class SpeedDisplay : MonoBehaviour
{
    public TextMeshProUGUI speedText;
    public Rigidbody karRigidbody;

    void Update()
    {
        if (karRigidbody == null) return;
        // Konversi m/s ke km/h
        float kecepatan = karRigidbody.linearVelocity.magnitude * 3.6f;
        speedText.text = Mathf.RoundToInt(kecepatan).ToString();
    }
}