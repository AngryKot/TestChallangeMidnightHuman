using UnityEngine;
using System.Collections; // Необходимо для IEnumerator

public class CandleFlame : MonoBehaviour
{
    public GameObject flame; // Ссылка на объект огня
    private bool isLit = true; // Флаг, отслеживающий состояние свечи
    private KeyCode actionKey = KeyCode.E; // Клавиша для действия
    public float extinguishTime = 5f; // Время до погашения свечи при касании Wind

    private Coroutine extinguishCoroutine; // Корутрина для погашения свечи

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Water"))
        {
            // Проверяем, если клавиша E не нажата, тогда тушим свечу
            if (!Input.GetKey(actionKey))
            {
                Extinguish(); // Потушить свечу при попадании в воду
            }
        }
        else if (other.CompareTag("Wind"))
        {
            // Запускаем корутину для погашения свечи
            StartExtinguishTimer();
        }
        else if (other.CompareTag("Fire"))
        {
            Ignite(); // Загораем свечу при попадании в огонь
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Wind"))
        {
            // Останавливаем корутину, если вышли из области Wind
            StopExtinguishTimer();
        }
    }

    void Update()
    {
        // Если свеча горит и игрок отпустил клавишу E, запускаем таймер заново
        if (isLit && Input.GetKeyUp(actionKey))
        {
            // Сбрасываем таймер, если свеча еще горит
            StartExtinguishTimer();
        }
    }

    private void StartExtinguishTimer()
    {
        if (extinguishCoroutine != null)
        {
            StopCoroutine(extinguishCoroutine); // Останавливаем предыдущую корутину, если она уже запущена
        }
        extinguishCoroutine = StartCoroutine(ExtinguishAfterTime(extinguishTime)); // Запускаем новый таймер
    }

    private void StopExtinguishTimer()
    {
        if (extinguishCoroutine != null)
        {
            StopCoroutine(extinguishCoroutine); // Останавливаем корутину, если она уже запущена
            extinguishCoroutine = null; // Сбрасываем ссылку на корутину
        }
    }

    IEnumerator ExtinguishAfterTime(float time)
    {
        for (float timer = 0; timer < time; timer += Time.deltaTime)
        {
            // Проверяем, если игрок нажал E, то сбрасываем таймер
            if (Input.GetKey(actionKey))
            {
                yield break; // Если E нажата, выходим из корутины
            }
            yield return null; // Ждем следующего кадра
        }
        Extinguish(); // Вызываем метод для погашения свечи
    }

    public void Extinguish()
    {
        if (!isLit) return; // Если уже потушена, выходим

        isLit = false; // Устанавливаем флаг потушенной свечи
        if (flame != null)
        {
            flame.SetActive(false); // Отключаем огонь
        }
        Debug.Log("Огонь свечи потушен!");
    }

    public void Ignite()
    {
        if (isLit) return; // Если уже горит, выходим

        isLit = true; // Устанавливаем флаг горящей свечи
        if (flame != null)
        {
            flame.SetActive(true); // Включаем огонь
        }
        Debug.Log("Огонь свечи зажжен!");
    }
}
