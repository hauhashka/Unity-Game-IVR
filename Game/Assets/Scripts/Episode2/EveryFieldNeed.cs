using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EveryFieldNeed : MonoBehaviour
{
    [SerializeField] int _nextscene;
    [SerializeField] int _neededNum;
    [SerializeField] AudioSource _audio;
    int counter = 0;
    public void IncreaseCounter()
    {
        counter++;
        if (counter == _neededNum)
        {
            _audio.Play();
            StartCoroutine(f());
        }
    }

    private IEnumerator f()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(_nextscene);
    }
}
