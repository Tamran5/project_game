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

    [Header("Koreksi Arah Ban")]
    public Vector3 offsetRotasi = new Vector3(0, 90, 0);

    private float inputMaju;
    private float inputBelok;
    private float inputMajuUI;
    private float inputBelokUI;

    void Update()
    {
        // Keyboard input
        float keyboard_maju = Input.GetAxis("Vertical");
        float keyboard_belok = Input.GetAxis("Horizontal");

        // Gabungkan keyboard + UI button (mana yang lebih besar)
        inputMaju = keyboard_maju != 0 ? keyboard_maju : inputMajuUI;
        inputBelok = keyboard_belok != 0 ? keyboard_belok : inputBelokUI;
    }

    // Dipanggil UIButton
    public void MoveInput(float input)
    {
        inputMajuUI = input;
    }

    public void SteerInput(float input)
    {
        inputBelokUI = input;
    }

    void FixedUpdate()
    {
        wcBelakangKiri.motorTorque = inputMaju * kekuatanMotor;
        wcBelakangKanan.motorTorque = inputMaju * kekuatanMotor;

        float sudutBelok = inputBelok * sudutBelokMaks;
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