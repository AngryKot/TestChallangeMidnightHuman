using UnityEngine;

public class HandMover : MonoBehaviour
{
    public Transform hand; // Объект руки, который нужно переместить
    public Transform handTarget; // Целевая точка для руки
    public KeyCode actionKey = KeyCode.E; // Клавиша для действия

    private bool isMovingHand = false; // Флаг для перемещения руки
    private float moveSpeed = 5f; // Скорость перемещения руки

    void Update()
    {
        // Проверяем нажатие клавиши для активации перемещения руки
        if (Input.GetKey(actionKey))
        {
            isMovingHand = true; // Включаем перемещение руки
        }
        else
        {
            isMovingHand = false; // Отключаем перемещение руки
        }

        // Если движение руки включено, перемещаем руку к целевой точке
        if (isMovingHand)
        {
            MoveHandToTarget();
        }
        else
        {
            ReturnHandToOriginalPosition();
        }
    }

    void MoveHandToTarget()
    {
        // Плавно перемещаем руку к целевой точке
        hand.position = Vector3.Lerp(hand.position, handTarget.position, Time.deltaTime * moveSpeed);

        // Плавно поворачиваем руку к целевой точке
        hand.rotation = Quaternion.Lerp(hand.rotation, handTarget.rotation, Time.deltaTime * moveSpeed);
    }

    void ReturnHandToOriginalPosition()
    {
        // Для возвращения руки на скелет, просто сбрасываем флаг и позволяем Unity управлять позицией и вращением руки
        // В этом случае предполагается, что рука всегда привязана к скелету
        hand.localPosition = Vector3.zero; // Устанавливаем местоположение руки относительно скелета
        hand.localRotation = Quaternion.identity; // Устанавливаем вращение руки относительно скелета
    }
}
