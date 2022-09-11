using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP : MonoBehaviour,IDamegable
{
    [SerializeField] GameObject _player;
    [SerializeField] float _maxHp = 500f;
    [SerializeField] float _enemyAttack = 100f;
    private float _currentHp = 0;

    private void Awake()
    {
        _currentHp = _maxHp;
    }
    void Update()
    {

    }

    public void Damage(int attackPower)
    {
        _currentHp -= _enemyAttack;

        if (_currentHp <= 0)
        {
            _player.SetActive(false);
        }
    }

}
