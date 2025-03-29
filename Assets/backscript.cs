using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // ����� ��� �������� �� ���� �����
    public void LoadNewScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    // ����� ��� ���������� �� ��������� �����
    public void LoadPreviousScene()
    {
        // �������� ������ ������� �����
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // ����������, �� � ��������� �����
        if (currentSceneIndex > 0)
        {
            // ����������� ��������� �����
            SceneManager.LoadScene(currentSceneIndex - 1);
        }
        else
        {
            Debug.Log("�� ����� �����, ���� ���������� ��� ����������.");
        }
    }
}