using UnityEngine;

public class pusatMassa : MonoBehaviour
{
    public Transform targetCenterOfMass; 
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (targetCenterOfMass != null)
        {
            rb.centerOfMass = targetCenterOfMass.localPosition;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
