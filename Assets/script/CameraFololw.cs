using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // ��������� �� ������
    public float distance = 10f; // ³������ ������ �� ������
    public float height = 5f; // ������ ������
    public float smoothSpeed = 0.125f; // �������� �������� ���������
    public float tiltAngle = 20f; // ����� ������ ����, ��� ������ �����
    public float rotationSpeed = 5f; // �������� ��������� ������ �� Y

    private float currentRotation = 0f; // �������� ��� ��������� ������

    void Update()
    {
        if (target == null) return;

        // ���������� ������ ������� ������ � ������� ���� �� �� X
        Vector3 direction = new Vector3(0, height, -distance); // ������ � �������� �� ���������
        Quaternion rotation = Quaternion.Euler(tiltAngle, currentRotation, 40); // ҳ���� ����� �� �� X, ��� ��� �� Z
        Vector3 desiredPosition = target.position + rotation * direction;

        // ������ ���������� ������ �� ������ �������
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // ������ ������ �������� �� ���������, ��������� ������ �������
        transform.LookAt(target.position + Vector3.up * 1.5f);
    }
}