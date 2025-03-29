using UnityEngine;

public class AttachWeapon : MonoBehaviour
{
    public Transform hand; // Сюди признач праву руку персонажа
    public GameObject swordPrefab; // Префаб меча

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
            equippedSword.transform.SetParent(hand); // Прикріпити до руки
        }
    }
}