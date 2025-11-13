using UnityEngine;
using UnityEngine.InputSystem;

public class SpawnBallOnInput : MonoBehaviour
{
    [Tooltip("Reference to your BallSpawner in the scene")]
    public BallSpawner ballSpawner;

    [Tooltip("Input action that will trigger the spawn (e.g. a button on the controller)")]
    public InputActionProperty spawnAction;

    private void OnEnable()
    {
        if (spawnAction.action != null)
        {
            spawnAction.action.performed += OnSpawnPerformed;
            spawnAction.action.Enable();
        }
    }

    private void OnDisable()
    {
        if (spawnAction.action != null)
        {
            spawnAction.action.performed -= OnSpawnPerformed;
            spawnAction.action.Disable();
        }
    }

    private void OnSpawnPerformed(InputAction.CallbackContext ctx)
    {
        if (ballSpawner != null)
            ballSpawner.SpawnBall();
    }
}
