using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class PengaturanAudio : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider sliderVolume;

    void Start()
    {
        // Ambil nilai volume dari AudioMixer lalu set ke slider
        float volume;
        audioMixer.GetFloat("MasterVol", out volume);
        // Konversi balik dari desibel ke nilai slider (0.0001 - 1)
        sliderVolume.value = Mathf.Pow(10, volume / 20);
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("MasterVol", Mathf.Log10(volume) * 20);
        // Simpan nilai agar tetap saat scene reload
        PlayerPrefs.SetFloat("MasterVolume", volume);
        PlayerPrefs.Save();
    }
}