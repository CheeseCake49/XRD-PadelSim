using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    [Header("Ball setup")]
    public GameObject ballPrefab;

    [Header("Spawn relative to player")]
    public Transform playerTransform;          // e.g. Main Camera or XR Origin
    public Vector3 localOffset = new Vector3(0f, -0.3f, 0.6f);
    // x = left/right, y = up/down, z = forward

    public void SpawnBall()
    {
        if (ballPrefab == null || playerTransform == null)
        {
            Debug.LogWarning("BallSpawner is missing ballPrefab or playerTransform.");
            return;
        }

        // Convert localOffset (relative to player) into world position
        Vector3 spawnPos = playerTransform.TransformPoint(localOffset);
        Quaternion spawnRot = Quaternion.LookRotation(playerTransform.forward, Vector3.up);

        GameObject ball = Instantiate(ballPrefab, spawnPos, spawnRot);

        // Start with no initial velocity so it just drops
        if (ball.TryGetComponent<Rigidbody>(out var rb))
        {
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }
}
