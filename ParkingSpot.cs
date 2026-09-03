using UnityEngine;

public class ParkingSpot : MonoBehaviour
{
    [Header("Park Kriterleri")]
    public float maxAllowedSpeed = 0.2f;
    public float requiredParkTime = 1.5f;
    public float maxAngleDifference = 20f;

    private float currentParkTimer = 0f;
    private bool isCarInside = false;
    private Rigidbody2D carRb;
    private Transform carTransform;
    private bool levelCompleted = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !levelCompleted)
        {
            isCarInside = true;
            carRb = other.GetComponent<Rigidbody2D>();
            carTransform = other.transform;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isCarInside = false;
            currentParkTimer = 0f;
        }
    }

    void Update()
    {
        if (!isCarInside || levelCompleted || carRb == null) return;

        // Hız kontrolü
        bool isStopped = carRb.linearVelocity.magnitude <= maxAllowedSpeed;

        // Açı kontrolü (0 ve 180 dereceye göre paralellik)
        float angleDiff = Quaternion.Angle(transform.rotation, carTransform.rotation);
        float normalizedAngle = Mathf.Min(angleDiff, Mathf.Abs(180f - angleDiff));
        bool isAligned = normalizedAngle <= maxAngleDifference;

        if (isStopped && isAligned)
        {
            currentParkTimer += Time.deltaTime;

            if (currentParkTimer >= requiredParkTime)
            {
                levelCompleted = true;
                
                // Paneli ekrana getir
                if (LevelManager.Instance != null)
                {
                    LevelManager.Instance.ShowWinUI();
                }
            }
        }
        else
        {
            currentParkTimer = 0f;
        }
    }
}