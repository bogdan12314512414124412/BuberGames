using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // Метод для переходу на нову сцену
    public void LoadNewScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    // Метод для повернення на попередню сцену
    public void LoadPreviousScene()
    {
        // Отримуємо індекс поточної сцени
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // Перевіряємо, чи є попередня сцена
        if (currentSceneIndex > 0)
        {
            // Завантажуємо попередню сцену
            SceneManager.LoadScene(currentSceneIndex - 1);
        }
        else
        {
            Debug.Log("Це перша сцена, немає попередньої для повернення.");
        }
    }
}