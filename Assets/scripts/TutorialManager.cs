using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public GameObject tutorialPanel;

    void Start()
    {
        Time.timeScale = 0f;
        tutorialPanel.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void MulaiGame()
    {
        tutorialPanel.SetActive(false);
        Time.timeScale = 1f;
    }
}