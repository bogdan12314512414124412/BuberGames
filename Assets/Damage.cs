using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float health = 100f;  // ��������� ������'� �����
    public float maxHealth = 100f;  // ����������� ������'� �����
    public float healthRegenRate = 1f;  // �������� ���������� ������'� (���� �������)

    // ����� ��� ��������� �����
    public void TakeDamage(float damage)
    {
        health -= damage;  // �������� ������'� �� �������� �����
        health = Mathf.Clamp(health, 0, maxHealth);  // ������������, �� ������'� �� ����� ������ �� 0

        if (health <= 0)
        {
            Die();  // ���� ������'� ������� ����, ��������� ����� �����
        }

        // ��������� ������'� � ������� ��� ������������ (����� ��������)
        Debug.Log("Player Health: " + health);
    }

    // ����� ��� ����� �����
    void Die()
    {
        // ����� ����� ����� (���������, ������� �����, ���������� ����� ����)
        Debug.Log("Player has died!");
        // ���������, ����� ��������� ��������� ���� ��� ���������� ����� �� ����� �����
        // gameObject.SetActive(false);  // ��������� �����
        // ��� ���������� �����
        // SceneManager.LoadScene(SceneManager.GetActiveScene().name);  // ���������� ������� �����
    }
}