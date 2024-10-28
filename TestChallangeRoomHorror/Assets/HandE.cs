using UnityEngine;

public class HandMover : MonoBehaviour
{
    public Transform hand; // ������ ����, ������� ����� �����������
    public Transform handTarget; // ������� ����� ��� ����
    public KeyCode actionKey = KeyCode.E; // ������� ��� ��������

    private bool isMovingHand = false; // ���� ��� ����������� ����
    private float moveSpeed = 5f; // �������� ����������� ����

    void Update()
    {
        // ��������� ������� ������� ��� ��������� ����������� ����
        if (Input.GetKey(actionKey))
        {
            isMovingHand = true; // �������� ����������� ����
        }
        else
        {
            isMovingHand = false; // ��������� ����������� ����
        }

        // ���� �������� ���� ��������, ���������� ���� � ������� �����
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
        // ������ ���������� ���� � ������� �����
        hand.position = Vector3.Lerp(hand.position, handTarget.position, Time.deltaTime * moveSpeed);

        // ������ ������������ ���� � ������� �����
        hand.rotation = Quaternion.Lerp(hand.rotation, handTarget.rotation, Time.deltaTime * moveSpeed);
    }

    void ReturnHandToOriginalPosition()
    {
        // ��� ����������� ���� �� ������, ������ ���������� ���� � ��������� Unity ��������� �������� � ��������� ����
        // � ���� ������ ��������������, ��� ���� ������ ��������� � �������
        hand.localPosition = Vector3.zero; // ������������� �������������� ���� ������������ �������
        hand.localRotation = Quaternion.identity; // ������������� �������� ���� ������������ �������
    }
}
