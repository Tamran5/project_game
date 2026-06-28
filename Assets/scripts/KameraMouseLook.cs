using UnityEngine;

public class KameraMouseLook : MonoBehaviour
{
    public float sensitivitas = 3f;

    private float rotasiYaw = 0f;
    private float rotasiPitch = 15f;

    void Start()
    {
        // Hapus cursor lock agar tombol UI bisa ditekan
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void LateUpdate()
    {
        // Kamera hanya bergerak saat mouse kanan ditekan
        if (Input.GetMouseButton(1))
        {
            rotasiYaw += Input.GetAxis("Mouse X") * sensitivitas;
            rotasiPitch -= Input.GetAxis("Mouse Y") * sensitivitas;
            rotasiPitch = Mathf.Clamp(rotasiPitch, -5f, 45f);
            transform.localRotation = Quaternion.Euler(rotasiPitch, rotasiYaw, 0f);
        }
    }
}