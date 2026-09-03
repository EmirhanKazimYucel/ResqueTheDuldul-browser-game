using UnityEngine;

public class TriggerZone : MonoBehaviour
{
    [Header("Harekete Geçecek Engel")]
    public MovingObstacle obstacleToTrigger;

    private bool isTriggered = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        // Tetikleyiciye araba (Player) bastıysa ve henüz tetiklenmediyse
        if (other.CompareTag("Player") && !isTriggered)
        {
            isTriggered = true;

            if (obstacleToTrigger != null)
            {
                obstacleToTrigger.StartMoving();
            }

            // Tetikleyici görevini yaptı, kendini devre dışı bıraksın
            gameObject.SetActive(false);
        }
    }
}