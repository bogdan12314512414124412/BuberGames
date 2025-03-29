using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement; // �� �������� ������ ��� ������ � SceneManager

public class GameLoader : MonoBehaviour
{
    public Transform player;  // ��������� �� ������ ���������

    public void LoadGame(int slotNumber)
    {
        // ��������� ����� �� ����� ����������
        string filePath = Application.persistentDataPath + "/save" + slotNumber + ".json";

        if (File.Exists(filePath))
        {
            // ������� ����� ����������
            string json = File.ReadAllText(filePath);
            GameData data = JsonUtility.FromJson<GameData>(json);

            // ³��������� ������� ���������
            player.position = new Vector3(data.playerX, data.playerY, data.playerZ);

            // ���, ��� ���������, �� ��� ������
            Debug.Log("��� ����������� � ����� " + slotNumber);

            // ������� �� ������ ����� (����� "GameSceneName" �� ���� ������� ����� �����)
            SceneManager.LoadScene("Gamescene"); // ������ "GameSceneName" �� ��'� ���� �����
        }
        else
        {
            Debug.LogError("���� ���������� �� ��������!");
        }
    }
}