using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader2 : MonoBehaviour  // ���������� ���
{
    // ����� ��� ������������ ����� �� �� ��'��
    public void LoadSceneByName(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    // ����� ��� ���������� �� ��������� �����
    public void LoadPreviousScene()
    {
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