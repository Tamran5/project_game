using UnityEngine;

public class KameraMouseLook : MonoBehaviour
{
    public float sensitivitas = 3f;

    private float rotasiYaw = 0f;
    private float rotasiPitch = 15f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        rotasiYaw = transform.eulerAngles.y;
        rotasiPitch = transform.eulerAngles.x;
    }

    void LateUpdate()
    {
        // Hapus semua Input lama - tidak dipakai di mobile
        Quaternion targetRotasi = Quaternion.Euler(rotasiPitch, rotasiYaw, 0f);
        transform.localRotation = Quaternion.Lerp(transform.localRotation, targetRotasi, Time.deltaTime * 10f);
    }
}