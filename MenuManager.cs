using UnityEngine;
using UnityEngine.SceneManagement; // Sahneleri yönetmek için gerekli

public class MenuManager : MonoBehaviour
{
    public void PlayGame()
    {
        // "Level_1" adındaki sahneyi yükler (Senin ilk bölümünün adı neyse onu yaz)
        SceneManager.LoadScene("Level_1"); 
    }

    public void QuitGame()
    {
        // Oyundan çıkar (Sadece derlenmiş oyunda çalışır, Unity editöründe çalışmaz)
        Application.Quit();
        Debug.Log("Oyundan Çıkıldı");
    }
}