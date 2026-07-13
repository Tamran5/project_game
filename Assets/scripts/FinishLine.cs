using UnityEngine;

public class FinishLine : MonoBehaviour
{
    public GameTimer gameTimer;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameTimer.LevelBerhasil();
        }
    }
}