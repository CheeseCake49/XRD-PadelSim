using UnityEngine;

public class RacketBehavior : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            collision.gameObject
                .GetComponent<BallImpactIndicator>()
                ?.RegisterRacketHit();
        }
    }
}
