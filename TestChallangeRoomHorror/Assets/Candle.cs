using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candle : MonoBehaviour
{

    public Transform characterTransform; // ������ �� Transform ���������
    public GameObject sword; // ������ �� ������ ����

    public Vector3 swordOffset; // �������� ���� ������������ "Hand"

    void Update()
    {
        // ��������� ������� � ������� "Hand" � ���������
        transform.position = characterTransform.position;
        transform.rotation = characterTransform.rotation;

        // ��������� ������� ���� ������������ "Hand"
        sword.transform.localPosition = swordOffset;
    }


}


