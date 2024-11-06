using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class TriggerRight: MonoBehaviour
{
    private int count = 0;
    public float delta_volume = 0.05f;
    private bool _isTrigger = false;
    private bool _isLameMusic = false;
    [SerializeField] private GameObject _player;
    [SerializeField] private Camera _camera;
    [SerializeField] private AudioSource _narratorAudioSource;
    [SerializeField] private AudioSource _musicSource;
    [SerializeField] private AudioClip _lameMusic;
    public Animator door;
    private void OnTriggerEnter(Collider other)
    {
        if (count == 0)
        {
            door.Play("openDoorRight");
            _narratorAudioSource.Stop();
            StartCoroutine(RightTrigger());
            count = 1;
        }
    }

    private void Update()
    {
        if (_isTrigger && !_isLameMusic)
        {
            _musicSource.volume -= delta_volume * Time.deltaTime;
            if (_musicSource.volume == 0)
            {
                _musicSource.Stop();
                _musicSource.clip = _lameMusic;
                _musicSource.Play();
                _musicSource.volume = 0;
                _isLameMusic = true;
            }
        }
        if (_isLameMusic)
        {

            Debug.Log('a');
            _musicSource.volume += delta_volume * Time.deltaTime;
            if ( _musicSource.volume >= 0.25)
            {
                _camera.GetComponent<Postprocess>().enabled = true;
            }
            if ( _musicSource.volume >= 0.5)
            {
                _isTrigger = false;
                _isLameMusic = false;
                
            }
        }
    }

    IEnumerator RightTrigger()
    {
        _player.GetComponent<Voice_Music>().enabled = false;
        yield return new WaitForSeconds(2);
        _isTrigger = true;
        
    }
}
