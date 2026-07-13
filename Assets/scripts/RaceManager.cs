using System.Collections;
using UnityEngine;
using TMPro;

public class RaceManager : MonoBehaviour
{
    [Header("Referensi UI & Objek")]
    public GameObject panelCaraBermain;
    public TextMeshProUGUI teksCountdown;
    public KontrolTrukWheel kontrolMobil;

    // --- TAMBAH REFERENSI INI ---
    public GameObject PauseButton;
    public GameObject speedPanel;

    public void TombolMulaiDiklik()
    {
        panelCaraBermain.SetActive(false);
        StartCoroutine(MulaiHitungMundur());
    }

    IEnumerator MulaiHitungMundur()
    {
        teksCountdown.gameObject.SetActive(true);

        teksCountdown.text = "3";
        yield return new WaitForSecondsRealtime(1f);

        teksCountdown.text = "2";
        yield return new WaitForSecondsRealtime(1f);

        teksCountdown.text = "1";
        yield return new WaitForSecondsRealtime(1f);

        teksCountdown.text = "GO!";

        Time.timeScale = 1f;

        if (kontrolMobil != null)
        {
            kontrolMobil.balapanDimulai = true;
        }

        // --- TAMBAH KODE INI UNTUK MUNCULKAN TOMBOL PAUSE ---
        if (PauseButton != null)
        {
            PauseButton.SetActive(true);
        }

        if (speedPanel != null)
        {
            speedPanel.SetActive(true);
        }

        yield return new WaitForSecondsRealtime(1f);
        teksCountdown.gameObject.SetActive(false);
    }
}