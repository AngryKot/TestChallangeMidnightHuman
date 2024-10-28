using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candle : MonoBehaviour
{

    public Transform characterTransform; // Ссылка на Transform персонажа
    public GameObject sword; // Ссылка на объект меча

    public Vector3 swordOffset; // Смещение меча относительно "Hand"

    void Update()
    {
        // Обновляем позицию и поворот "Hand" к персонажу
        transform.position = characterTransform.position;
        transform.rotation = characterTransform.rotation;

        // Обновляем позицию меча относительно "Hand"
        sword.transform.localPosition = swordOffset;
    }


}


