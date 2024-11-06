using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Voice_Music : MonoBehaviour
{
    [SerializeField] private AudioSource _player;
    [SerializeField] private AudioSource _music;
    void Update()
    {
        if (!_player.isPlaying)
        {
            _music.volume = 0.26f;
        }
    }
}
