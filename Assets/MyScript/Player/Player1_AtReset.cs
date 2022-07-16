using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1_AtReset : MonoBehaviour
{
    [SerializeField] GameObject _AtEf1;
    [SerializeField] GameObject _AtEf2;

    public void StartEffect()
    {
        _AtEf1.SetActive(true);
    }
    public void StartEffect2()
    {
        _AtEf2.SetActive(true);
    }
    public void ReseEffect()
    {
        _AtEf1.SetActive(false);
        _AtEf2.SetActive(false);
    }
}

