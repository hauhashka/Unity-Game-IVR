using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EveryFieldNeed : MonoBehaviour
{
    [SerializeField] int _neededNum;
    [SerializeField] AudioSource _audio;
    int counter = 0;
    public void IncreaseCounter()
    {
        counter++;
        if (counter == _neededNum)
        {
            _audio.Play();
        }
    }
}
