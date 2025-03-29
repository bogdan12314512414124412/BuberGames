using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class ZombieAI : MonoBehaviour
{
    public Transform player;
    public float attackRange = 2f;
    public float moveSpeed = 3.5f;
    public float attackDelay = 1f;
    public float stopDistance = 1f; // ��������� �� ��� ���� �����������
    public float maxCloseDistance = 0.5f; // ����������� �������, �� ��� ���� �� ������ ���� ������� ������� �� ������

    private NavMeshAgent agent;
    private Animator animator;
    private bool isAttacking = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        agent.speed = moveSpeed;
        agent.stoppingDistance = stopDistance; // ����������� �� ������� ��������� �������
    }

    void Update()
    {
        if (player == null)
        {
            Debug.LogWarning("Player not assigned!");
            return;
        }

        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // ���� ���� ����������� � ����� �������� �����, ��������� ���� �� ��������� �����
        if (distanceToPlayer <= attackRange && !isAttacking)
        {
            agent.isStopped = true;  // ��������� ����
            StartAttack();
        }
        // ���� ���� ����������� �� ������ �����, ��� �� ����� ������� �� ������, ������ ���� �� ������
        else if (distanceToPlayer > attackRange && distanceToPlayer > stopDistance)
        {
            agent.isStopped = false;  // ���������� �������� �� ������
            animator.SetBool("IsWalking", true);
            agent.SetDestination(player.position);
        }
        else
        {
            // ���� ���� ��������� ������� �� ������, ��������� ������� ������
            animator.SetBool("IsWalking", false);
        }

        // ������ ��������, �� ���� ������� ������� �� ������
        if (distanceToPlayer < maxCloseDistance)
        {
            // ³���������� �� �������� ������� �����, ���� ���� ������� ������� �� ������
            Vector3 directionAwayFromPlayer = (transform.position - player.position).normalized;
            Vector3 newPosition = transform.position + directionAwayFromPlayer * 0.5f; // ³������� ���� �� 0.5 �����
            agent.SetDestination(newPosition); // ��������� ������� ����
        }
    }

    void StartAttack()
    {
        isAttacking = true;
        animator.SetTrigger("Attack"); // ��������� ������� �����
        StartCoroutine(AttackDelay());
    }

    IEnumerator AttackDelay()
    {
        yield return new WaitForSeconds(attackDelay); // �������� ���� �����
        isAttacking = false;
    }
}