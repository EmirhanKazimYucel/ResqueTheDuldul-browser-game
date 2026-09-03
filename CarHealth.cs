using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CarHealth : MonoBehaviour
{
    [Header("UI Bağlantısı")]
    public UIManager uiManager;

    [Header("Ses")]
    public AudioClip crashSound;
    private bool isDead = false;

    void Start()
    {
        if (uiManager == null)
        {
            uiManager = Object.FindFirstObjectByType<UIManager>();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (isDead) return;

        // Motora çarparsa
        if (collision.gameObject.CompareTag("Motorcycle"))
        {
            TriggerCrash(true);
        }
        // Duvara / engele çarparsa
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            TriggerCrash(false);
        }
    }

    // Parametre alan fonksiyon (MovingObstacle burayı çağırır)
    public void TriggerCrash(bool hitMotorcycle = false)
    {
        if (isDead) return;
        isDead = true;

        StartCoroutine(CrashSequence(hitMotorcycle));
    }

    IEnumerator CrashSequence(bool hitMotorcycle)
    {
        var controller = GetComponent<TopDownCarController>();
        if (controller != null) controller.enabled = false;

        var rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = Vector2.zero;
            rb.angularVelocity = 0f;
            rb.bodyType = RigidbodyType2D.Static;
        }

        if (crashSound != null)
        {
            Vector3 soundPos = transform.position;
            if (Camera.main != null)
            {
                soundPos.z = Camera.main.transform.position.z;
            }
            AudioSource.PlayClipAtPoint(crashSound, soundPos, 1f);
        }

        yield return new WaitForSeconds(0.4f);

        if (uiManager != null)
        {
            if (hitMotorcycle)
                uiManager.ShowMotorcycleCrashScreen();
            else
                uiManager.ShowCrashScreen();
        }
    }
}