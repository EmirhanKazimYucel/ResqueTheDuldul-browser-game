using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class TopDownCarController : MonoBehaviour
{
    [Header("Araba Ayarları")]
    public float accelerationFactor = 25f;
    public float turnFactor = 3.5f;
    public float driftFactor = 0.85f;
    public float maxSpeed = 15f;

    [Header("Fren Lambası")]
    public SpriteRenderer carSpriteRenderer;
    public Sprite normalSprite;
    public Sprite brakeSprite;

    [Header("Drift İzleri & Ses")]
    public TrailRenderer[] tireTrails;      // Arka iki tekerlek izi
    public AudioSource skidAudioSource;     // Drift sesi kaynağı
    public float driftTireSmokeThreshold = 2.5f; // Kayma eşiği

    private float accelerationInput = 0f;
    private float steeringInput = 0f;
    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        if (carSpriteRenderer == null) carSpriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    void Update()
    {
        accelerationInput = Input.GetAxisRaw("Vertical");
        steeringInput = Input.GetAxisRaw("Horizontal");

        UpdateBrakeLights();
        HandleDriftEffects();
    }

    void FixedUpdate()
    {
        ApplyEngineForce();
        KillOrthogonalVelocity();
        ApplySteering();
    }

    void ApplyEngineForce()
    {
        if (rb.linearVelocity.magnitude > maxSpeed && accelerationInput > 0) return;
        Vector2 engineForceVector = transform.up * (accelerationInput * accelerationFactor);
        rb.AddForce(engineForceVector, ForceMode2D.Force);
    }

    void ApplySteering()
    {
        float minSpeedBeforeAllowTurning = Mathf.Clamp01(rb.linearVelocity.magnitude / 8f);
        float directionSign = Vector2.Dot(rb.linearVelocity, transform.up) >= 0 ? 1f : -1f;
        float rotationAngle = transform.rotation.eulerAngles.z - (steeringInput * turnFactor * minSpeedBeforeAllowTurning * directionSign);
        rb.MoveRotation(rotationAngle);
    }

    void KillOrthogonalVelocity()
    {
        Vector2 forwardVelocity = transform.up * Vector2.Dot(rb.linearVelocity, transform.up);
        Vector2 rightVelocity = transform.right * Vector2.Dot(rb.linearVelocity, transform.right);
        rb.linearVelocity = forwardVelocity + (rightVelocity * driftFactor);
    }

    void UpdateBrakeLights()
    {
        if (carSpriteRenderer == null || normalSprite == null || brakeSprite == null) return;
        float forwardVelocity = Vector2.Dot(rb.linearVelocity, transform.up);
        bool isReversing = accelerationInput < 0 || forwardVelocity < -0.1f;
        carSpriteRenderer.sprite = isReversing ? brakeSprite : normalSprite;
    }

    void HandleDriftEffects()
    {
        // Arabanın yana doğru kayma hızını hesapla
        float lateralVelocity = Vector2.Dot(rb.linearVelocity, transform.right);
        bool isDrifting = Mathf.Abs(lateralVelocity) > driftTireSmokeThreshold;

        // İzleri aç / kapat
        if (tireTrails != null)
        {
            foreach (var trail in tireTrails)
            {
                if (trail != null) trail.emitting = isDrifting;
            }
        }

        // Drift sesini aç / kapat
        if (skidAudioSource != null)
        {
            if (isDrifting && !skidAudioSource.isPlaying)
            {
                skidAudioSource.Play();
            }
            else if (!isDrifting && skidAudioSource.isPlaying)
            {
                skidAudioSource.Stop();
            }
        }
    }
}