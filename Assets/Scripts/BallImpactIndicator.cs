using UnityEngine;

public class BallImpactIndicator : MonoBehaviour
{
    public GameObject greenPrefab;
    public GameObject redPrefab;

    public Transform serveLinePlane;
    public Transform net;

    private int hitCounter = -1;   // starts at -1 so first post-racket hit becomes 0
    private bool wasHitByRacket = false;

    private const float indicatorLifetime = 10f;

    public void RegisterRacketHit()
    {
        wasHitByRacket = true;
        hitCounter = -1;   // ensures first floor hit is counted as 0 (and displayed)
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!wasHitByRacket)
            return;

        hitCounter++;

        // show indicators only for hit 0, 1, and 2
        if (hitCounter >= 0 && hitCounter <= 2)
        {
            ContactPoint contact = collision.contacts[0];

            bool isLegal = contact.point.z > serveLinePlane.position.z && contact.point.z < net.position.z;

            GameObject prefab = isLegal ? greenPrefab : redPrefab;

            GameObject indicator = Instantiate(
                prefab,
                contact.point,
                Quaternion.LookRotation(contact.normal)
            );

            Destroy(indicator, indicatorLifetime);
        }

        // stop after 3 displayed hits
        if (hitCounter >= 2)
            wasHitByRacket = false;
    }
}
