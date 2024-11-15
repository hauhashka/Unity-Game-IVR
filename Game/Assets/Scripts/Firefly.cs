using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Firefly : MonoBehaviour
{

    private RectTransform rectTransform;
    public float lifespan = 1.5f; // ����� ����� ���������
    public float speed = 100f; // �������� �������� (��� Canvas ���������)
    private Vector2 direction; // ����������� ��������

    void Start()
    {
        // �������� RectTransform � ������������� ��������� ����������� ��������
        rectTransform = GetComponent<RectTransform>();
        direction = Random.insideUnitCircle.normalized;
    }

    void Update()
    {
        // ������� ���������
        rectTransform.anchoredPosition += direction * speed * Time.deltaTime;

        // ��������� ����� �����
        lifespan -= Time.deltaTime;

        // ���������� ������, ����� ����� ����� �����
        if (lifespan <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void OnClick()
    {
        // ���������� ��������� ��� �������
        FireflySpawner.instance.IncreaseCounter();

        Destroy(gameObject);
    }

}
