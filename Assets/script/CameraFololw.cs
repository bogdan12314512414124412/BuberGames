using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Посилання на гравця
    public float distance = 10f; // Відстань камери від гравця
    public float height = 5f; // Висота камери
    public float smoothSpeed = 0.125f; // Швидкість плавного слідування
    public float tiltAngle = 20f; // Нахил камери вниз, щоб бачити спину
    public float rotationSpeed = 5f; // Швидкість обертання камери по Y

    private float currentRotation = 0f; // Поточний кут обертання камери

    void Update()
    {
        if (target == null) return;

        // Обчислюємо бажану позицію камери з нахилом вниз по осі X
        Vector3 direction = new Vector3(0, height, -distance); // Вектор в напрямку до персонажа
        Quaternion rotation = Quaternion.Euler(tiltAngle, currentRotation, 40); // Тільки нахил по осі X, без змін по Z
        Vector3 desiredPosition = target.position + rotation * direction;

        // Плавне переміщення камери до бажаної позиції
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Камера завжди дивиться на персонажа, коригуючи висоту погляду
        transform.LookAt(target.position + Vector3.up * 1.5f);
    }
}