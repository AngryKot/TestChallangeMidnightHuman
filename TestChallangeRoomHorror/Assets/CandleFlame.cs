using UnityEngine;
using System.Collections; // ���������� ��� IEnumerator

public class CandleFlame : MonoBehaviour
{
    public GameObject flame; // ������ �� ������ ����
    private bool isLit = true; // ����, ������������� ��������� �����
    private KeyCode actionKey = KeyCode.E; // ������� ��� ��������
    public float extinguishTime = 5f; // ����� �� ��������� ����� ��� ������� Wind

    private Coroutine extinguishCoroutine; // ��������� ��� ��������� �����

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Water"))
        {
            // ���������, ���� ������� E �� ������, ����� ����� �����
            if (!Input.GetKey(actionKey))
            {
                Extinguish(); // �������� ����� ��� ��������� � ����
            }
        }
        else if (other.CompareTag("Wind"))
        {
            // ��������� �������� ��� ��������� �����
            StartExtinguishTimer();
        }
        else if (other.CompareTag("Fire"))
        {
            Ignite(); // �������� ����� ��� ��������� � �����
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Wind"))
        {
            // ������������� ��������, ���� ����� �� ������� Wind
            StopExtinguishTimer();
        }
    }

    void Update()
    {
        // ���� ����� ����� � ����� �������� ������� E, ��������� ������ ������
        if (isLit && Input.GetKeyUp(actionKey))
        {
            // ���������� ������, ���� ����� ��� �����
            StartExtinguishTimer();
        }
    }

    private void StartExtinguishTimer()
    {
        if (extinguishCoroutine != null)
        {
            StopCoroutine(extinguishCoroutine); // ������������� ���������� ��������, ���� ��� ��� ��������
        }
        extinguishCoroutine = StartCoroutine(ExtinguishAfterTime(extinguishTime)); // ��������� ����� ������
    }

    private void StopExtinguishTimer()
    {
        if (extinguishCoroutine != null)
        {
            StopCoroutine(extinguishCoroutine); // ������������� ��������, ���� ��� ��� ��������
            extinguishCoroutine = null; // ���������� ������ �� ��������
        }
    }

    IEnumerator ExtinguishAfterTime(float time)
    {
        for (float timer = 0; timer < time; timer += Time.deltaTime)
        {
            // ���������, ���� ����� ����� E, �� ���������� ������
            if (Input.GetKey(actionKey))
            {
                yield break; // ���� E ������, ������� �� ��������
            }
            yield return null; // ���� ���������� �����
        }
        Extinguish(); // �������� ����� ��� ��������� �����
    }

    public void Extinguish()
    {
        if (!isLit) return; // ���� ��� ��������, �������

        isLit = false; // ������������� ���� ���������� �����
        if (flame != null)
        {
            flame.SetActive(false); // ��������� �����
        }
        Debug.Log("����� ����� �������!");
    }

    public void Ignite()
    {
        if (isLit) return; // ���� ��� �����, �������

        isLit = true; // ������������� ���� ������� �����
        if (flame != null)
        {
            flame.SetActive(true); // �������� �����
        }
        Debug.Log("����� ����� ������!");
    }
}
