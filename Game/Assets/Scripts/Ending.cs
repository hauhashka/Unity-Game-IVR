using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ending: MonoBehaviour
{
    private int count = 0;
    [SerializeField] AudioSource _narrator;
    [SerializeField] AudioClip _clip;
    private void OnTriggerEnter(Collider other)
    {
        if (count == 0)
        {
            _narrator.Stop();
            _narrator.clip = _clip;
            _narrator.Play();
            count = 1;
        }
    }
}
