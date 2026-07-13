using UnityEngine;

public class FinishLine : MonoBehaviour
{
    public GameTimer gameTimer;

    void OnTriggerEnter(Collider other)
    {
        // Mengecek tag "Player" pada objek utama/induk yang memiliki Rigidbody
        if (other.attachedRigidbody != null && other.attachedRigidbody.CompareTag("Player"))
        {
            gameTimer.LevelBerhasil();
        }
    }
}