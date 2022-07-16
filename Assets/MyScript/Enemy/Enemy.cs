using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour,IDamegable
{
    [SerializeField] GameObject _player1;//オブジェクトを参照する
    [SerializeField] GameObject _player2;
    [SerializeField] float _speed = 1f;
    [SerializeField] int _enemyHP = 3;
    [SerializeField] int _attackPower = 1;

    private Animator _anim;
    //private float _xSpeed = 0f;
   // private float _h = 0f;

    private void Start()
    {
        _anim = GetComponent<Animator>();
    }
    private void Update()
    {
        //_anim.SetFloat("Move", 0.1f);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        //別のスクリプトで書く
        if (collision.gameObject.tag == "Player" && _player1 == true  || (collision.gameObject.tag == "Player2" && _player2 == true))
        {
            Vector2 targeting = (_player1.transform.position - transform.position).normalized;//プレイヤー-敵キャラの位置関係から方向を取得し、速度を一定化
            GetComponent<Rigidbody2D>().velocity = new Vector2(targeting.x  * _speed, 0);//プレイヤー追う

       /*     if (_h > 0)
            {
                transform.localScale = new Vector2(1, 1);
                _anim.SetFloat("Move", 1f);
                _xSpeed = _speed;
            }
            else if (_h < 0)
            {
                transform.localScale = new Vector2(-1, 1);
                _anim.SetFloat("Move", 1f);
                _xSpeed = -_speed;
            }
            else
            {
                _anim.SetFloat("Move", 0.1f);
                _xSpeed = 0f;
            }*/
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            IDamegable player = collision.gameObject.GetComponent<IDamegable>();
            if(player != null)
            {
                player.Damage(_attackPower);
            }
        }
    }
    public void Damage(int attackPower)
    {
        _enemyHP -= attackPower;
        if (_enemyHP <= 0)
        {
            this.gameObject.SetActive(false);
        }
    }

}
