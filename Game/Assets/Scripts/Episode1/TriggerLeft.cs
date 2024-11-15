using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerLeft : MonoBehaviour
{
    private int count  = 0;
    [SerializeField] private Transform _player;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip[] Sounds;
    private bool _isTrigger = false;
    private bool _iscursed = false;
    public Animator door;
    private void OnTriggerEnter(Collider other)
    {
        if (count == 0)
        {
            _isTrigger = true;
            door.Play("openDoorLeft");
            StartCoroutine(CursedImage());
            StartCoroutine(Screaming());
            count++;
        }
    }

    IEnumerator CursedImage()
    {
        yield return new WaitForSeconds(Random.Range(2, 8));
        while (true)
        {
            _iscursed = !_iscursed;
            if (_iscursed)
            {
                _player.eulerAngles = new Vector3(0, _player.eulerAngles.y, Random.Range(-50, 50));
                yield return new WaitForSeconds(0.5f);
            } else
            {
                _player.eulerAngles = new Vector3(0, _player.eulerAngles.y, 0);
                yield return new WaitForSeconds(Random.Range(2, 8));
            }
        }
    }

    IEnumerator Screaming()
    {
        yield return new WaitForSeconds(Random.Range(4, 10));
        while (true)
        {
            int a = Random.Range(0, Sounds.Length);
             _audioSource.PlayOneShot(Sounds[a]);
            yield return new WaitForSeconds(Random.Range(4, 10));
        }
    }
}
