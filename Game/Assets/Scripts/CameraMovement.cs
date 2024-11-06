using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private GameObject self;
    [SerializeField] private Camera next_cam;
    [SerializeField] private GameObject _player;
    [SerializeField] private Transform _player_target;
    [SerializeField] private Transform _target;
    [SerializeField] private Vector3 _offcet;
    [SerializeField] private float _speed = 1f;
    // Update is called once per frame
    void Update()
    {

        var nextPosition = Vector3.Lerp(transform.position, _target.position, Time.deltaTime * _speed);

        if (transform.position.y - _target.position.y <= 0.2)
        {
            StartCoroutine(TurnCamera());
            if (transform.eulerAngles.y >= 180)
            {
                nextPosition = Vector3.Lerp(transform.position, _player_target.transform.position + _offcet, Time.deltaTime * _speed);
                transform.position = nextPosition;
                if (Mathf.Abs(transform.position.z - _player_target.transform.position.z) <= 2)
                {
                    next_cam.enabled = true;
                    _player.GetComponent<FPSController>().enabled = true;
                    Destroy(self);

                }
            }
        }
        else
        {
            transform.position = nextPosition;
        }
    }

    
    IEnumerator TurnCamera()
    {
        while (transform.eulerAngles.y < 180)
        {
            transform.eulerAngles += new Vector3(0f, 0.2f, 0f) * Time.deltaTime;
            yield return null;
        }
    }
}

