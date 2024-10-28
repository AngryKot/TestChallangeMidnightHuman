using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target; // —сылка на объект персонажа
    public bool lockCursor = true;
    public float mouseSensitivity = 10;
    public Vector2 pitchMinMax = new Vector2(-40, 85); // ќграничени€ по вертикали
    public Vector2 yawMinMax = new Vector2(-90, 90); // ќграничени€ по горизонтали дл€ "огл€дывани€"

    public float rotationSmoothTime = 0.12f;
    Vector3 rotationSmoothVelocity;
    Quaternion targetRotation; //  ватернион дл€ хранени€ целевого вращени€

    float yaw;
    float pitch;

    void Start()
    {
        if (lockCursor)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        // ”станавливаем начальный угол yaw в направлении персонажа
        yaw = 0;
        pitch = 0;
    }

    void LateUpdate()
    {
        // ѕолучаем направление камеры в зависимости от движени€ мыши
        yaw += Input.GetAxis("Mouse X") * mouseSensitivity;
        pitch -= Input.GetAxis("Mouse Y") * mouseSensitivity;

        // ќграничиваем углы вертикального и горизонтального вращени€
        pitch = Mathf.Clamp(pitch, pitchMinMax.x, pitchMinMax.y);
        yaw = Mathf.Clamp(yaw, yawMinMax.x, yawMinMax.y);

        // –ассчитываем целевое вращение как отклонение от направлени€ персонажа
        targetRotation = Quaternion.Euler(pitch, target.eulerAngles.y + yaw, 0);

        // ѕлавно переходим к целевому вращению
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime / rotationSmoothTime);

        //  амера следует за позицией персонажа
        transform.position = target.position;
    }
}
