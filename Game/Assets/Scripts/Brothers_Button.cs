using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brothers_Button : MonoBehaviour
{
    [SerializeField] GameObject _image;
    public void Onclick()
    {
        Destroy(_image);
    }
}
