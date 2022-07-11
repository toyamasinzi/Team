using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetEffect : MonoBehaviour
{
    [SerializeField] GameObject _AtEf;

    public void StartEffect()
    {
        _AtEf.SetActive(true);
    }
    public void ReseEffect()
    {
        _AtEf.SetActive(false);
    }
}
