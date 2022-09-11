using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class HpGauge : MonoBehaviour
{
    [SerializeField] float _time = 0f;
    [SerializeField] Slider _slider =default;
    [SerializeField] float _currentHp = 100f;
    [SerializeField] float _damega = 5f;

    void Start()
    {
        _slider = GetComponent<Slider>();
        _slider.value = _currentHp;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            HPGauge(_slider.value - _damega);
        }
    }
    void HPGauge(float value)
    {
        DOTween.To(() => _slider.value, x => _slider.value = x, value,_time);
    }
}
