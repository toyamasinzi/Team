using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GimmickCamera : MonoBehaviour
{
    [SerializeField] GameObject camera1;

    float _count = 2f;
    [SerializeField] float _time;

    private void Update()
    {
        _time += Time.deltaTime;
    }
    private void OnDisable()
    {
        if (gameObject.tag == "Finish")//プレイヤー１またはプレイヤー２
        {
            _time = 0;
            if (_time > _count)
            {
                camera1.SetActive(false);
            }
        }
    }
}