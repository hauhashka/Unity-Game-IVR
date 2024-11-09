using Ink.Parsed;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InputField : MonoBehaviour
{
    [SerializeField] EveryFieldNeed _c;
    [SerializeField] string _goodvalue;
    [SerializeField] GameObject _inputField;
    [SerializeField] Material _material;
    private string input;
    public void ReadStringInput(string s)
    {
        input = s;
        if (input == _goodvalue)
        {
            _inputField.GetComponent<Image>().sprite = null;
            _inputField.GetComponent<Image>().material = _material;
            _inputField.GetComponent<Selectable>().interactable = false;
            _c.IncreaseCounter();
        }
    }
}