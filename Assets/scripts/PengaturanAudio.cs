using UnityEngine;
using UnityEngine.Audio; // Wajib untuk Audio Mixer

public class PengaturanAudio : MonoBehaviour
{
    public AudioMixer audioMixer;

    // Fungsi ini akan dipanggil otomatis oleh Slider saat digeser
    public void SetVolume(float volume)
    {
        // Rumus konversi angka Slider (0.0001 - 1) ke Desibel Audio Mixer (-80 - 0)
        audioMixer.SetFloat("MasterVol", Mathf.Log10(volume) * 20);
    }
}