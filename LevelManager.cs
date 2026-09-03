using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    // Diğer scriptlerin bu yöneticiye kolayca ulaşması için Singleton referansı
    public static LevelManager Instance;

    [Header("UI Referansı")]
    public GameObject winPanel;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Arabayı başarıyla park ettiğimizde çağrılacak
    public void ShowWinUI()
    {
        if (winPanel != null)
        {
            winPanel.SetActive(true); // Gizlediğimiz paneli ekrana getirir
        }
    }

    // Butona tıklandığında sonraki sahneyi açacak fonksiyon
    public void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;

        // Eğer sırada başka bir bölüm/sahne varsa onu aç
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            // Başka sahne kalmadıysa en baştaki sahneye (Seviye 1'e) döner
            Debug.Log("Tüm bölümler bitti! Başa dönülüyor.");
            SceneManager.LoadScene(0);
        }
    }
}