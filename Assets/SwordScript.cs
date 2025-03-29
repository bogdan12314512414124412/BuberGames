using UnityEngine;

public class AttachWeapon : MonoBehaviour
{
    public Transform hand; // ���� ������� ����� ���� ���������
    public GameObject swordPrefab; // ������ ����

    private GameObject equippedSword;

    void Start()
    {
        EquipSword();
    }

    void EquipSword()
    {
        if (equippedSword == null)
        {
            equippedSword = Instantiate(swordPrefab, hand.position, hand.rotation);
            equippedSword.transform.SetParent(hand); // ��������� �� ����
        }
    }
}