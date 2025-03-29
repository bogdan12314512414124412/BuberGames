using UnityEngine;
using UnityEngine.SceneManagement;  // Необхідно для роботи з сценами

public class SceneLoader23 : MonoBehaviour
{
    // Метод для завантаження сцени за її ім'ям
    public void LoadSceneByName(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}