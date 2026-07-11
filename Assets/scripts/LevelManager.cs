using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public Button level2Button;
    public GameObject lockIcon; // icon gembok di Level 2

    void Start()
    {
        // Cek apakah Level 1 sudah selesai
        bool level1Selesai = PlayerPrefs.GetInt("Level1Selesai", 0) == 1;

        level2Button.interactable = level1Selesai;

        if (lockIcon != null)
            lockIcon.SetActive(!level1Selesai);
    }

    public void MulaiLevel1()
    {
        SceneManager.LoadScene("Level1"); // nama scene level 1 kamu
    }

    public void MulaiLevel2()
    {
        SceneManager.LoadScene("Level2"); // nama scene level 2
    }


    public void Kembali()
    {
        SceneManager.LoadScene("mainmenu");
    }
}