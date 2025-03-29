using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject panelSettings;

    private void Start()
    {
        panelSettings.SetActive(false);
    }

    public void Play()
    {
        SceneManager.LoadScene("Menu");
        // SceneManager.LoadScene(1);
    }

    public void Back()
    {
        SceneManager.LoadScene("MenuPanel");
        // SceneManager.LoadScene(0);
    }

    public void Settings()
    {
        if (panelSettings.activeSelf == false)
        {
            panelSettings.SetActive(true);
        }
        else if (panelSettings.activeSelf == true)
        {
            panelSettings.SetActive(false);
        }
    }

    public void Exit()
    {
        Application.Quit();
    }
}
