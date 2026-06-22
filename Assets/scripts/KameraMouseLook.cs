using UnityEngine;

public class KameraMouseLook : MonoBehaviour
{
    public float sensitivitas = 3f;
    
    private float rotasiYaw = 0f;   // Menengok Kiri-Kanan (Sumbu Y)
    private float rotasiPitch = 15f; // Menunduk-Dongak (Sumbu X)

    void Start()
    {
        // Mengunci kursor mouse di tengah layar agar tidak keluar dari jendela game
        Cursor.lockState = CursorLockMode.Locked;
    }

    void LateUpdate()
    {
        // Membaca geseran mouse
        rotasiYaw += Input.GetAxis("Mouse X") * sensitivitas;
        rotasiPitch -= Input.GetAxis("Mouse Y") * sensitivitas;

        // Membatasi sudut nunduk/dongak agar kamera tidak bablas tembus ke bawah aspal
        rotasiPitch = Mathf.Clamp(rotasiPitch, -5f, 45f);

        // Putar "Tongsis"-nya
        transform.localRotation = Quaternion.Euler(rotasiPitch, rotasiYaw, 0f);
    }
}