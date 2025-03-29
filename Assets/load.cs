using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader2 : MonoBehaviour  // Перейменуй тут
{
    // Метод для завантаження сцени за її ім'ям
    public void LoadSceneByName(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    // Метод для повернення на попередню сцену
    public void LoadPreviousScene()
    {
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