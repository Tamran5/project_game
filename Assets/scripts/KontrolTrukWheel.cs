using UnityEngine;

public class KontrolTrukWheel : MonoBehaviour
{
    // --- TAMBAHAN BARU: Variabel pengunci status balapan ---
    public bool balapanDimulai = false;

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

    [Header("Koreksi Arah Ban")]
    public Vector3 offsetRotasi = new Vector3(0, 90, 0);

    private float inputMaju;
    private float inputBelok;

    // Dipanggil UIButton
    public void MoveInput(float input)
    {
        inputMaju = input;
    }

    public void SteerInput(float input)
    {
        inputBelok = input;
    }

    void FixedUpdate()
    {
        // --- TAMBAHAN BARU: Mencegah mobil bergerak sebelum GO! ---
        // Jika balapanDimulai bernilai false, paksa nilai gas dan belok menjadi 0
        float gasAktif = balapanDimulai ? inputMaju : 0f;
        float belokAktif = balapanDimulai ? inputBelok : 0f;

        // Gunakan variabel 'gasAktif' alih-alih 'inputMaju'
        float torque = Mathf.Abs(gasAktif) > 0.01f ? gasAktif * kekuatanMotor : 0f;

        // Otomatis mengerem (300f) jika tidak ada input gasAktif
        float rem = Mathf.Abs(gasAktif) > 0.01f ? 0f : 300f;

        wcBelakangKiri.motorTorque = torque;
        wcBelakangKanan.motorTorque = torque;

        wcDepanKiri.brakeTorque = rem;
        wcDepanKanan.brakeTorque = rem;
        wcBelakangKiri.brakeTorque = rem;
        wcBelakangKanan.brakeTorque = rem;

        // Gunakan variabel 'belokAktif' alih-alih 'inputBelok'
        float sudutBelok = belokAktif * sudutBelokMaks;
        wcDepanKiri.steerAngle = sudutBelok;
        wcDepanKanan.steerAngle = sudutBelok;

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
        collider.GetWorldPose(out posisi, out rotasi);
        meshTransform.position = posisi;
        meshTransform.rotation = rotasi * Quaternion.Euler(offsetRotasi);
    }
}