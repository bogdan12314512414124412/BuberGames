using UnityEngine;

public class ZombieDamage : MonoBehaviour
{
    public Transform player;  // ��������� �� ������
    public float damageAmount = 10f;  // ʳ������ �����, ��� �������� ����
    public float damageInterval = 1f;  // �������� �� ���������� ����� (� ��������)
    public float attackRadius = 2f;  // �����, � ����� ���� ���� ��������� �����

    private float lastDamageTime = 0f;  // ��� ���������� ��������� �����

    void Update()
    {
        if (player == null)
        {
            Debug.LogWarning("Player not assigned!");
            return;
        }

        // ���������� ������� �� ���� �� �������
         float distanceToPlayer = Vector3.Distance(transform.position, player.position);

       
       

         // ��������, �� ���� ����������� � ����� ������ ����� � �� ������ ��� ��� ��������� �����
        if (distanceToPlayer <= attackRadius && Time.time - lastDamageTime >= damageInterval)
        {
            ApplyDamage();  // �������� �����
            lastDamageTime = Time.time;  // ��������� ��� ���������� ��������� �����
        }
    }

    void ApplyDamage()
    {
        // �������� ��������� PlayerHealth �� ��'��� ������
        PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();

        if (playerHealth != null)
        {
            Debug.Log("Zombie is dealing damage to the player.");
            playerHealth.TakeDamage(damageAmount);  // �������� ����� ������
        }
        else
        {
            Debug.LogWarning("PlayerHealth component not found on the player.");
        }
    }
}