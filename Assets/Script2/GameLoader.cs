using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement; // не забудьте додати для роботи з SceneManager

public class GameLoader : MonoBehaviour
{
    public Transform player;  // Посилання на вашого персонажа

    public void LoadGame(int slotNumber)
    {
        // Створення шляху до файлу збереження
        string filePath = Application.persistentDataPath + "/save" + slotNumber + ".json";

        if (File.Exists(filePath))
        {
            // Читання файлу збереження
            string json = File.ReadAllText(filePath);
            GameData data = JsonUtility.FromJson<GameData>(json);

            // Відновлення позиції персонажа
            player.position = new Vector3(data.playerX, data.playerY, data.playerZ);

            // Лог, щоб перевірити, що все працює
            Debug.Log("Гра завантажена з слоту " + slotNumber);

            // Перехід на ігрову сцену (заміна "GameSceneName" на вашу реальну назву сцени)
            SceneManager.LoadScene("Gamescene"); // замініть "GameSceneName" на ім'я вашої сцени
        }
        else
        {
            Debug.LogError("Файл збереження не знайдено!");
        }
    }
}