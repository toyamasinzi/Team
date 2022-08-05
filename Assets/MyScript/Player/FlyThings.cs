using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyThings : MonoBehaviour
{

    [SerializeField] GameObject _AtEf;
    [SerializeField] GameObject Player1;
    void Start()
    {
    }
    void FlyStartEffect()
    {
        Player1 = Instantiate(_AtEf, transform.position, Quaternion.identity);

    }
}
