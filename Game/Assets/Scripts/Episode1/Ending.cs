using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ending: MonoBehaviour
{
    private int count = 0;
    private float time;
    [SerializeField] int _nextscene;
    [SerializeField] AudioSource _narrator;
    [SerializeField] AudioClip _clip;
    private void Update()
    {
        if (count == 1)
        {
            if (!_narrator.isPlaying)
            {
                StartCoroutine(NextScene());
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (count == 0)
        {
            _narrator.Stop();
            _narrator.clip = _clip;
            _narrator.Play();
            float cliplen = _clip.length;
            count = 1;
        }
        
    }

    private IEnumerator NextScene()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(_nextscene);
    }
}
