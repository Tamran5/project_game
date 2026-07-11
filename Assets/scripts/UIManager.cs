using UnityEngine;
using UnityEngine.UI; // Jika butuh UI standar

public class UIManager : MonoBehaviour
{
    public GameObject instructionPanel; // Masukkan BackgroundDim ke sini nanti

    // Fungsi ini dipanggil saat tombol diklik
    public void MulaiBalapan()
    {
        // Menyembunyikan panel instruksi
        instructionPanel.SetActive(false);

        // Memulai waktu game jika sebelumnya di-pause
        Time.timeScale = 1f;

        Debug.Log("Balapan Dimulai!");
    }
}