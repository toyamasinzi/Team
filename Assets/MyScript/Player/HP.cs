using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] int _playerHP = 5;
    [SerializeField] int _enemyAttack = 1;

    void Start()
    {
    }
    void Update()
    {
        if(_playerHP == 0)
        {
            player.SetActive(false);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy") 
        {
            _playerHP -= _enemyAttack;
        }
    }
}
