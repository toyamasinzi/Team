using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP : MonoBehaviour,IDamegable
{
    [SerializeField] GameObject _player;
    [SerializeField] int _maxHp = 5;
    [SerializeField] int _enemyAttack = 1;
    private int _currentHp = 0;

    private void Start()
    {
        _currentHp = _maxHp;
    }
    void Update()
    {

    }
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if(collision.gameObject.tag == "Enemy") 
    //    {
           
    //    }
    //}

    public void Damage(int attackPower)
    {
        _currentHp -= _enemyAttack;

        if (_currentHp <= 0)
        {
            _player.SetActive(false);
        }
    }

}
