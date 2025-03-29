using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class SaveManager : MonoBehaviour
{
    
    public GameObject saveSlotPanel;   
    public Transform player;           

    void Start()
    {
        
        saveSlotPanel.SetActive(false);
    }

    
    public void OpenSaveSlots()
    {
        saveSlotPanel.SetActive(true);  
    }

    
    public void SaveToSlot(int slotNumber)
    {
        
        GameData data = new GameData
        {
            playerX = player.position.x,  
            playerY = player.position.y,  
            playerZ = player.position.z,  
            playerLevel = 5,              
            health = 100,                 
            coins = 50                    
        };

        
        string json = JsonUtility.ToJson(data);

        
        File.WriteAllText(Application.persistentDataPath + "/save" + slotNumber + ".json", json);

       
        Debug.Log("Гра збережена в слот " + slotNumber);

       
        SceneManager.LoadScene("Menu");
    }
}