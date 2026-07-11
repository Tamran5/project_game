using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameTimer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public GameObject levelClearPanel;
    public GameObject timerObject; // drag GameObject countdown ke sini
    private float sisaWaktu;
    private bool gameBerjalan = true;
    private int detikTerakhir = -1;

    void Start()
    {
        string namaScene = SceneManager.GetActiveScene().name;
        sisaWaktu = namaScene == "Level2" ? 300f : 60f;
    }

    void Update()
    {
        if (Time.timeScale == 0f) return;

        if (gameBerjalan && sisaWaktu > 0)
        {
            sisaWaktu -= Time.deltaTime;
            int detikSekarang = Mathf.FloorToInt(sisaWaktu);
            if (detikSekarang != detikTerakhir)
            {
                detikTerakhir = detikSekarang;
                UpdateTampilanWaktu(sisaWaktu);
            }
        }
        else if (sisaWaktu <= 0 && gameBerjalan)
        {
            sisaWaktu = 0;
            gameBerjalan = false;
            UpdateTampilanWaktu(0);
            LevelBerhasil();
        }
    }

    void LevelBerhasil()
    {
        Time.timeScale = 0f;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        // Sembunyikan timer
        if (timerObject != null)
            timerObject.SetActive(false);

        string namaScene = SceneManager.GetActiveScene().name;
        if (namaScene == "Level1")
        {
            PlayerPrefs.SetInt("Level1Selesai", 1);
            PlayerPrefs.Save();
        }
        else if (namaScene == "Level2")
        {
            PlayerPrefs.SetInt("Level2Selesai", 1);
            PlayerPrefs.Save();
        }

        if (levelClearPanel != null)
            levelClearPanel.SetActive(true);
    }

    void UpdateTampilanWaktu(float waktu)
    {
        int menit = Mathf.FloorToInt(waktu / 60);
        int detik = Mathf.FloorToInt(waktu % 60);
        timerText.text = string.Format("{0:00}:{1:00}", menit, detik);
    }
}