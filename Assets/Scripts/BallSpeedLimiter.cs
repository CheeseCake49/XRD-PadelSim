using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BallSpeedLimiter : MonoBehaviour
{
    public float maxSpeed = 25f;   // tweak in inspector

    Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Vector3 v = rb.linearVelocity;

        float maxSpeedSq = maxSpeed * maxSpeed;
        if (v.sqrMagnitude > maxSpeedSq)
        {
            rb.linearVelocity = v.normalized * maxSpeed;
        }
    }
}
