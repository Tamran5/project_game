using UnityEngine;

public class SistemSein : MonoBehaviour
{
    [Header("Objek Lampu Sein")]
    public GameObject seinKiri;
    public GameObject seinKanan;

    [Header("Setelan Kedipan")]
    public float kecepatanKedip = 0.35f; // Durasi kedip dalam detik

    private bool seinKiriAktif = false;
    private bool seinKananAktif = false;
    private float timer;
    private bool kondisiLampu = false;

    void Start()
    {
        // Pastikan lampu mati semua di awal game
        MatikanSemuaLampu();
    }

    void Update()
    {
        // 1. Input Tombol Q untuk Sein Kiri
        if (Input.GetKeyDown(KeyCode.Q))
        {
            seinKiriAktif = !seinKiriAktif;
            seinKananAktif = false; // Otomatis matikan sein kanan jika kiri aktif
            timer = 0f;
            kondisiLampu = seinKiriAktif;
        }

        // 2. Input Tombol E untuk Sein Kanan
        if (Input.GetKeyDown(KeyCode.E))
        {
            seinKananAktif = !seinKananAktif;
            seinKiriAktif = false; // Otomatis matikan sein kiri jika kanan aktif
            timer = 0f;
            kondisiLampu = seinKananAktif;
        }

        // 3. Logika Menghitung Waktu Kedipan
        if (seinKiriAktif || seinKananAktif)
        {
            timer += Time.deltaTime;
            if (timer >= kecepatanKedip)
            {
                kondisiLampu = !kondisiLampu; // Bolak-balik nyala-mati
                timer = 0f;
            }

            // Eksekusi nyala mati objek di scene
            if (seinKiriAktif)
            {
                seinKiri.SetActive(kondisiLampu);
                seinKanan.SetActive(false);
            }
            else if (seinKananAktif)
            {
                seinKanan.SetActive(kondisiLampu);
                seinKiri.SetActive(false);
            }
        }
        else
        {
            MatikanSemuaLampu();
        }
    }

    void MatikanSemuaLampu()
    {
        if (seinKiri != null) seinKiri.SetActive(false);
        if (seinKanan != null) seinKanan.SetActive(false);
    }
}