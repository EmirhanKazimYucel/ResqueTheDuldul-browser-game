using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [Header("Standart Paneller")]
    public GameObject crashPanel;              // Klasik kaza paneli
    public GameObject motorcycleCrashPanel;    // Motosiklet kaza paneli
    public GameObject winPanel;                // Klasik bölüm tamamlama paneli

    [Header("Son Bölüme Özel")]
    public GameObject finalWinPanel;           // 4. seviyeye özel kupa/gifli büyük bitiş paneli

    void Start()
    {
        // Oyun başında sahnede hangisi varsa hepsini gizle
        if (crashPanel != null) crashPanel.SetActive(false);
        if (motorcycleCrashPanel != null) motorcycleCrashPanel.SetActive(false);
        if (winPanel != null) winPanel.SetActive(false);
        if (finalWinPanel != null) finalWinPanel.SetActive(false);
    }

    // Duvar / Engel kazası
    public void ShowCrashScreen()
    {
        if (crashPanel != null) crashPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    // Motosiklet kazası
    public void ShowMotorcycleCrashScreen()
    {
        if (motorcycleCrashPanel != null)
            motorcycleCrashPanel.SetActive(true);
        else if (crashPanel != null)
            crashPanel.SetActive(true);

        Time.timeScale = 0f;
    }

    // Park Tamamlandığında Çalışan Fonksiyon
    public void ShowWinScreen()
    {
        // 1. Eğer bu sahnede Son Bölüm Paneli tanımlanmışsa ONU AÇ:
        if (finalWinPanel != null)
        {
            finalWinPanel.SetActive(true);
        }
        // 2. Yoksa diğer seviyelerdeki klasik paneli aç:
        else if (winPanel != null)
        {
            winPanel.SetActive(true);
        }

        Time.timeScale = 0f;
    }

    public void RestartLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("StartMenu"); // Ana menü sahnenizin adı
    }

    public void NextLevel()
    {
        Time.timeScale = 1f;
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            SceneManager.LoadScene("StartMenu");
        }
    }
}