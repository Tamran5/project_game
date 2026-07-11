using UnityEngine;
using UnityEngine.SceneManagement;

public class FungsiMenu : MonoBehaviour
{
    public void KeluarDariGame()
    {
        Debug.Log("Pemain keluar dari game!");
        Application.Quit();
    }

    public void BukaLevelSelect()
    {
        SceneManager.LoadScene("LevelSelect");
    }

    public void KeMainMenu()
    {
        SceneManager.LoadScene("mainmenu");
    }
}