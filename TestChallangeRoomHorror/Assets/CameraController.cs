using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target; // ������ �� ������ ���������
    public bool lockCursor = true;
    public float mouseSensitivity = 10;
    public Vector2 pitchMinMax = new Vector2(-40, 85); // ����������� �� ���������
    public Vector2 yawMinMax = new Vector2(-90, 90); // ����������� �� ����������� ��� "�����������"

    public float rotationSmoothTime = 0.12f;
    Vector3 rotationSmoothVelocity;
    Quaternion targetRotation; // ���������� ��� �������� �������� ��������

    float yaw;
    float pitch;

    void Start()
    {
        if (lockCursor)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        // ������������� ��������� ���� yaw � ����������� ���������
        yaw = 0;
        pitch = 0;
    }

    void LateUpdate()
    {
        // �������� ����������� ������ � ����������� �� �������� ����
        yaw += Input.GetAxis("Mouse X") * mouseSensitivity;
        pitch -= Input.GetAxis("Mouse Y") * mouseSensitivity;

        // ������������ ���� ������������� � ��������������� ��������
        pitch = Mathf.Clamp(pitch, pitchMinMax.x, pitchMinMax.y);
        yaw = Mathf.Clamp(yaw, yawMinMax.x, yawMinMax.y);

        // ������������ ������� �������� ��� ���������� �� ����������� ���������
        targetRotation = Quaternion.Euler(pitch, target.eulerAngles.y + yaw, 0);

        // ������ ��������� � �������� ��������
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime / rotationSmoothTime);

        // ������ ������� �� �������� ���������
        transform.position = target.position;
    }
}
