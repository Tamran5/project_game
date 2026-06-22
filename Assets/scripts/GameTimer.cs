using UnityEngine;
using TMPro; // Wajib ada untuk TextMeshPro

public class GameTimer : MonoBehaviour
{
    public TextMeshProUGUI timerText; // Tarik objek UI kamu ke sini
    public float sisaWaktu = 60f; // Durasi dalam detik
    private bool gameBerjalan = true;

    void Update()
    {
        if (gameBerjalan && sisaWaktu > 0)
        {
            sisaWaktu -= Time.deltaTime; // Mengurangi waktu setiap detik
            UpdateTampilanWaktu(sisaWaktu);
        }
        else if (sisaWaktu <= 0)
        {
            sisaWaktu = 0;
            gameBerjalan = false;
            Debug.Log("Waktu Habis!");
            // Tambahkan logika game over di sini
        }
    }

    void UpdateTampilanWaktu(float waktu)
    {
        int menit = Mathf.FloorToInt(waktu / 60);
        int detik = Mathf.FloorToInt(waktu % 60);
        timerText.text = string.Format("{0:00}:{1:00}", menit, detik);
    }
}