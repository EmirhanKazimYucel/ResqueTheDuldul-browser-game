using UnityEngine;

public class MovingObstacle : MonoBehaviour
{
    [Header("Hareket Ayarları")]
    public float speed = 12f;          // Motosikletin geçiş hızı
    public float lifeTime = 5f;        // Geçtikten kaç saniye sonra sahneden silinsin?
    
    private bool isMoving = false;

    void Update()
    {
        if (isMoving)
        {
            // Baktığı yön boyunca (transform.up) ileriye doğru hareket eder
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }
    }

    // Tetikleyici bu fonksiyonu çağırarak motoru başlatacak
    public void StartMoving()
    {
        if (!isMoving)
        {
            isMoving = true;
            // Ekrandan çıktıktan sonra boşuna sahnede kalmasın, kendini silsin
            Destroy(gameObject, lifeTime);
        }
    }

    // Motosiklet oyuncunun arabasına vurduğu anda çalışır
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Arabanın can/kaza scriptini bul ve kazayı tetikle
            CarHealth carHealth = collision.gameObject.GetComponent<CarHealth>();
            if (carHealth != null)
            {
                carHealth.TriggerCrash(true);
            }

            // Motosikletin de anında hareketi kesilsin, arabayı itemesin
            isMoving = false;
        }
    }
}