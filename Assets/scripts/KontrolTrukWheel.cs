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
        float torque = Mathf.Abs(inputMaju) > 0.01f ? inputMaju * kekuatanMotor : 0f;
        float rem = Mathf.Abs(inputMaju) > 0.01f ? 0f : 300f;

        wcBelakangKiri.motorTorque = torque;
        wcBelakangKanan.motorTorque = torque;

        wcDepanKiri.brakeTorque = rem;
        wcDepanKanan.brakeTorque = rem;
        wcBelakangKiri.brakeTorque = rem;
        wcBelakangKanan.brakeTorque = rem;

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