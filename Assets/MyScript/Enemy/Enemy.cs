using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamegable
{
    [SerializeField] GameObject _player1;//オブジェクトを参照する
                                         // [SerializeField] GameObject _player2;
    [SerializeField] float _speed = 1f;
    [SerializeField] int _enemyHP = 3;
    [SerializeField] int _attackPower = 1;

    bool _plt = false;
    private Animator _anim;

    private void Start()
    {
        _anim = GetComponent<Animator>();
    }
    private void Update()
    {
        if (_plt == false)
        {
            _anim.SetFloat("Move", 0.1f);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Player2")
        {
            _plt = true;    
                Vector2 targeting = (_player1.transform.position - transform.position).normalized;//プレイヤー-敵キャラの位置関係から方向を取得し、速度を一定化
                GetComponent<Rigidbody2D>().velocity = new Vector2(targeting.x * _speed, 0);//プレイヤー追う
                if (targeting.x > 0)
                {
                    transform.rotation = new Quaternion(0, 1, 0, 0);
                    _anim.SetFloat("Move", 1f);
                }
                else
                {
                    transform.rotation = new Quaternion(0, 0, 0, 0);
                    _anim.SetFloat("Move", 1f);
                }
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Player2")
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            _plt = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            IDamegable player = collision.gameObject.GetComponent<IDamegable>();
            if (player != null)
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
