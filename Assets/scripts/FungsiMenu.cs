using UnityEngine;

public class FungsiMenu : MonoBehaviour
{
    // Fungsi ini akan dipanggil saat tombol Quit diklik
    public void KeluarDariGame()
    {
        // Memunculkan teks di tab Console Unity sebagai tanda tombol berfungsi
        Debug.Log("Pemain keluar dari game!"); 
        
        
        Application.Quit(); 
    }
}