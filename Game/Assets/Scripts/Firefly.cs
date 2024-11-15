using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Firefly : MonoBehaviour
{

    private RectTransform rectTransform;
    public float lifespan = 1.5f; // Время жизни светлячка
    public float speed = 100f; // Скорость движения (для Canvas координат)
    private Vector2 direction; // Направление движения

    void Start()
    {
        // Получаем RectTransform и устанавливаем случайное направление движения
        rectTransform = GetComponent<RectTransform>();
        direction = Random.insideUnitCircle.normalized;
    }

    void Update()
    {
        // Двигаем светлячка
        rectTransform.anchoredPosition += direction * speed * Time.deltaTime;

        // Уменьшаем время жизни
        lifespan -= Time.deltaTime;

        // Уничтожаем объект, когда время жизни вышло
        if (lifespan <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void OnClick()
    {
        // Уничтожаем светлячка при нажатии
        FireflySpawner.instance.IncreaseCounter();

        Destroy(gameObject);
    }

}
