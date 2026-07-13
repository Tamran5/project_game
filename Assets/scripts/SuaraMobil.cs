using UnityEngine;

public class SuaraMobil : MonoBehaviour
{
    public AudioSource audioMesin;
    public float minPitch = 0.8f;
    public float maxPitch = 2.5f;
    public float minSpeed = 0f;
    public float maxSpeed = 100f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (audioMesin != null)
        {
            audioMesin.loop = true;
            audioMesin.Play();
        }
    }

    void Update()
    {
        if (audioMesin == null || rb == null) return;

        float kecepatan = rb.linearVelocity.magnitude * 3.6f;
        float pitchNormal = Mathf.InverseLerp(minSpeed, maxSpeed, kecepatan);
        audioMesin.pitch = Mathf.Lerp(minPitch, maxPitch, pitchNormal);

        // Volume naik saat bergerak
        audioMesin.volume = Mathf.Lerp(0.3f, 1f, pitchNormal);
    }
}