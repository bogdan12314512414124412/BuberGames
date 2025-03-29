using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SettingsManager : MonoBehaviour
{
    public Button moveUpButton;
    public Button moveDownButton;
    public Button moveLeftButton;
    public Button moveRightButton;
    public Button saveButton;

    public TMP_Text moveUpText;
    public TMP_Text moveDownText;
    public TMP_Text moveLeftText;
    public TMP_Text moveRightText;

    private string currentAction = "";

    private void Start()
    {
        // Завантаження збережених налаштувань або дефолтних значень
        moveUpText.text = PlayerPrefs.GetString("MoveUp", "W");
        moveDownText.text = PlayerPrefs.GetString("MoveDown", "S");
        moveLeftText.text = PlayerPrefs.GetString("MoveLeft", "A");
        moveRightText.text = PlayerPrefs.GetString("MoveRight", "D");

        // Прив'язка обробників подій
        moveUpButton.onClick.AddListener(() => ChangeKey("MoveUp"));
        moveDownButton.onClick.AddListener(() => ChangeKey("MoveDown"));
        moveLeftButton.onClick.AddListener(() => ChangeKey("MoveLeft"));
        moveRightButton.onClick.AddListener(() => ChangeKey("MoveRight"));
        saveButton.onClick.AddListener(SaveSettings);
    }

    private void ChangeKey(string action)
    {
        currentAction = action;
        StartCoroutine(WaitForKeyPress());
    }

    private System.Collections.IEnumerator WaitForKeyPress()
    {
        bool keyPressed = false;
        string newKey = "";

        while (!keyPressed)
        {
            foreach (KeyCode key in System.Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKeyDown(key))
                {
                    newKey = key.ToString().ToUpper(); // стандартний формат
                    keyPressed = true;
                    break;
                }
            }
            yield return null;
        }

        if (!string.IsNullOrEmpty(newKey))
        {
            PlayerPrefs.SetString(currentAction, newKey);
            PlayerPrefs.Save();
            UpdateKeyText(currentAction, newKey);
        }
    }

    private void UpdateKeyText(string action, string newKey)
    {
        switch (action)
        {
            case "MoveUp":
                moveUpText.text = newKey;
                break;
            case "MoveDown":
                moveDownText.text = newKey;
                break;
            case "MoveLeft":
                moveLeftText.text = newKey;
                break;
            case "MoveRight":
                moveRightText.text = newKey;
                break;
        }
    }

    private void SaveSettings()
    {
        PlayerPrefs.SetString("MoveUp", moveUpText.text.Trim().ToUpper());
        PlayerPrefs.SetString("MoveDown", moveDownText.text.Trim().ToUpper());
        PlayerPrefs.SetString("MoveLeft", moveLeftText.text.Trim().ToUpper());
        PlayerPrefs.SetString("MoveRight", moveRightText.text.Trim().ToUpper());
        PlayerPrefs.Save();

        Debug.Log("Settings saved successfully!");
    }

    // Допоміжна функція для безпечного парсингу тексту у KeyCode
    public static KeyCode GetKeyCodeFromText(string keyString, KeyCode fallback)
    {
        try
        {
            return (KeyCode)System.Enum.Parse(typeof(KeyCode), keyString.Trim().ToUpper());
        }
        catch
        {
            Debug.LogWarning($"Invalid key string: '{keyString}', fallback to {fallback}");
            return fallback;
        }
    }
}