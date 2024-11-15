using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FireflySpawner : MonoBehaviour
{
    [SerializeField] int _nextscene;
    [SerializeField] AudioSource _audio;
    [SerializeField] AudioClip _win;
    private bool _isActive = true;
    public static FireflySpawner instance;
    int coutner = 0;
    public GameObject fireflyPrefab; // ѕрефаб светл€чка
    public RectTransform spawnArea; // ќбласть Canvas дл€ по€влени€ светл€чков
    public float spawnInterval = 1f; // »нтервал по€влени€ светл€чков

    private float timer;

    private void Awake()
    {
        instance = this;
    }

    void Update()
    {
        timer += Time.deltaTime;

        // ѕо€вление нового светл€чка
        if (timer >= spawnInterval)
        {
            SpawnFirefly();
            timer = 0f;
        }
    }

    void SpawnFirefly()
    {
        if (_isActive)
        {
            // √енерируем случайную позицию в пределах области Canvas
            float x = Random.Range(-spawnArea.rect.width / 2, spawnArea.rect.width / 2);
            float y = Random.Range(-spawnArea.rect.height / 2, spawnArea.rect.height / 2);
            Vector2 spawnPosition = new Vector2(x, y);

            // —оздаем светл€чка как дочерний элемент Canvas
            GameObject firefly = Instantiate(fireflyPrefab, spawnArea);
            firefly.GetComponent<RectTransform>().anchoredPosition = spawnPosition;
        }
    }
    
    public void IncreaseCounter()
    {
        coutner++;
        Debug.Log(coutner);
        _audio.Play();
        if (coutner == 10)
        {
            _audio.clip = _win;
            _audio.Play();
            _isActive = false;
            StartCoroutine(f());
            SceneManager.LoadScene(_nextscene);
        }
    }

    IEnumerator f()
    {
        yield return new WaitForSeconds(2);
    }
}