using UnityEngine;

public class DeathZone : MonoBehaviour
{
    private SpawnBallManager spawner;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            Destroy(collision.gameObject);
            SpawnBallManager.instance.SpawnNewBallOnPaddle();
        }
    }
}
