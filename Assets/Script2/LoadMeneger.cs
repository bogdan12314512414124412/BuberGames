using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadManager : MonoBehaviour
{
    public Transform player; 
    public Button slot1Button, slot2Button, slot3Button; 

    void Start()
    {
        CheckSavedGames(); 
    }

    void CheckSavedGames()
    {
        
        slot1Button.interactable = File.Exists(Application.persistentDataPath + "/save1.json");
        slot2Button.interactable = File.Exists(Application.persistentDataPath + "/save2.json");
        slot3Button.interactable = File.Exists(Application.persistentDataPath + "/save3.json");
    }

    public void LoadFromSlot(int slotNumber)
    {
        string path = Application.persistentDataPath + "/save" + slotNumber + ".json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            GameData data = JsonUtility.FromJson<GameData>(json);

            
            PlayerPrefs.SetFloat("playerX", data.playerX);
            PlayerPrefs.SetFloat("playerY", data.playerY);
            PlayerPrefs.SetFloat("playerZ", data.playerZ);
            PlayerPrefs.SetInt("playerLevel", data.playerLevel);
            PlayerPrefs.SetInt("health", data.health);
            PlayerPrefs.SetInt("coins", data.coins);
            PlayerPrefs.SetInt("loadSlot", slotNumber); 

            
            SceneManager.LoadScene("GameScene");
        }
        else
        {
            Debug.Log("Немає збереження в слоті " + slotNumber);
        }
    }
}