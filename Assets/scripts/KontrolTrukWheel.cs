using UnityEngine;

public class KontrolTrukWheel : MonoBehaviour
{
    [Header("Wheel Colliders Fisika")]
    public WheelCollider wcDepanKiri;
    public WheelCollider wcDepanKanan;
    public WheelCollider wcBelakangKiri;
    public WheelCollider wcBelakangKanan;

    [Header("Visual Roda (Mesh)")]
    public Transform meshDepanKiri;
    public Transform meshDepanKanan;
    public Transform meshBelakangKiri;
    public Transform meshBelakangKanan;

    [Header("Setelan Performa")]
    public float kekuatanMotor = 1500f;
    public float sudutBelokMaks = 30f;

    [Header("Koreksi Arah Ban (Ubah di Sini!)")]
    public Vector3 offsetRotasi = new Vector3(0, 90, 0); // Angka awal untuk dicoba

    private float inputMaju;
    private float inputBelok;

    void Update()
    {
        // Membaca input keyboard W/S/A/D
        inputMaju = Input.GetAxis("Vertical");
        inputBelok = Input.GetAxis("Horizontal");
    }

    void FixedUpdate()
    {
        // 1. Jalankan roda belakang (Penggerak Belakang / RWD)
        wcBelakangKiri.motorTorque = inputMaju * kekuatanMotor;
        wcBelakangKanan.motorTorque = inputMaju * kekuatanMotor;

        // 2. Belokkan roda depan
        float sudutBelok = inputBelok * sudutBelokMaks;
        wcDepanKiri.steerAngle = sudutBelok;
        wcDepanKanan.steerAngle = sudutBelok;

        // 3. Sinkronkan posisi & rotasi visual ban dengan fisika Wheel Collider
        UpdatePosisiRoda(wcDepanKiri, meshDepanKiri);
        UpdatePosisiRoda(wcDepanKanan, meshDepanKanan);
        UpdatePosisiRoda(wcBelakangKiri, meshBelakangKiri);
        UpdatePosisiRoda(wcBelakangKanan, meshBelakangKanan);
    }

    void UpdatePosisiRoda(WheelCollider collider, Transform meshTransform)
    {
        if (meshTransform == null) return;

        Vector3 posisi;
        Quaternion rotasi;

        // Mengambil data posisi fisika roda di dunia game
        collider.GetWorldPose(out posisi, out rotasi);

        // Menyamakan posisi visual
        meshTransform.position = posisi;

        // Menerapkan rotasi dengan offset yang bisa diedit di Inspector
        meshTransform.rotation = rotasi * Quaternion.Euler(offsetRotasi);
    }
}