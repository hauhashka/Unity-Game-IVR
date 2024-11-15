using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class Exit : MonoBehaviour
{
    public int _nextscene;
    [SerializeField] AudioSource m_AudioSource;
    public void PointerEnters()
    {
        m_AudioSource.Play();
        StartCoroutine(f());

        
    }

    IEnumerator f()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(_nextscene);
    }
}
