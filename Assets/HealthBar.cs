using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public PlayerHealth playerHealth;  // ��������� �� PlayerHealth
    public Image healthBarFill;  // ����� ��� �������� Image (���������� ������� �������)

    void Start()
    {
        // �������� PlayerHealth, ���� �� �� �� ��� �������� � ��������
        if (playerHealth == null)
        {
            playerHealth = FindObjectOfType<PlayerHealth>();
        }

        // �������� Image ���������� ������� ������'�, ���� �� ������� � ��������
        if (healthBarFill == null)
        {
            healthBarFill = GetComponentInChildren<Image>();
        }
    }

    void Update()
    {
        // ��������� fillAmount ��� ������� ������'� �������� �� ��������� ������'�
        if (playerHealth != null && healthBarFill != null)
        {
            healthBarFill.fillAmount = playerHealth.health / playerHealth.maxHealth;  // ���������� ��������
        }
    }
}