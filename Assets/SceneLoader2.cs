using UnityEngine;
using UnityEngine.SceneManagement;  // ��������� ��� ������ � �������

public class SceneLoader23 : MonoBehaviour
{
    // ����� ��� ������������ ����� �� �� ��'��
    public void LoadSceneByName(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}