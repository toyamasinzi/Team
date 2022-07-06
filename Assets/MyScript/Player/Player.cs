using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player: MonoBehaviour
{
    [SerializeField] float _speed = 0f;
    [SerializeField] float _jumpPower = 15f;
    [SerializeField] float _time = 0f;
    [SerializeField] GameObject _player2;
    [SerializeField] GameObject _camera1;
    [SerializeField] GameObject _camera2;
    [SerializeField] float _at = 0f;

    private float _count = 3f;
    private float _ac = 0.5f;
    private bool _test = false;
    private float _xSpeed = 0f;
    private Animator _anim;
    private float _h = 0f;
    private int _jumpCount = 0;
    private Rigidbody2D _rb2d; 
    private Vector2 _dir = new Vector2(0, 0);

    void Start()
    {
         _anim = GetComponent<Animator>();
        _rb2d = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        _player2.transform.position = gameObject.transform.position;
        _time += Time.deltaTime;
        _h = Input.GetAxisRaw("Horizontal");
        _xSpeed = _speed;
            if (_h > 0)

            {
                transform.localScale = new Vector2(1, 1);
                _anim.SetFloat("Move", 1f);
                _xSpeed = _speed;
            }
            else if (_h < 0)
            {
                transform.localScale = new Vector2(-1, 1);
                _anim.SetFloat("Move", 1f);
                _xSpeed =- _speed;

            }

            else
            {
                _anim.SetFloat("Move", 0.1f);
                _xSpeed = 0f;
            }
        Vector2 dir = new Vector2(_h, 0);
        Vector2 b = dir.normalized * _speed;
        b.y = _rb2d.velocity.y;
        _rb2d.velocity = b;

        if (Input.GetKey("q") && _time > _count)
        { 
            _player2.SetActive(true);
            gameObject.SetActive(false);
            _camera2.SetActive(true);
            _camera1.SetActive(false);
            _time = 0;
        }
        if(Input.GetButtonDown("Jump") && _jumpCount　< 2)
        {
            _rb2d.velocity = Vector2.zero;
            _rb2d.AddForce(transform.up * _jumpPower, ForceMode2D.Impulse);
            _jumpCount++;
        }
        if(Input.GetButtonDown("Fire1") && !_test )
        {
            _anim.SetBool("Check", true);
            _anim.SetFloat("Attack", 0.2f);
            _test = true;
            StartCoroutine("Conbo");

        }
        if (Input.GetButtonDown("Fire2") && !_test)
        {
            _anim.SetBool("DashAt", true);
            _test = true;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            _jumpCount = 0;
        }
    }
    private IEnumerator Conbo()
    {

        yield return new WaitForSeconds(1f);
    }
    
    /// <summary>
    /// アニメーションイベントから呼び出す
    /// </summary>
    public void ResetAnim()
    {
        _anim.SetBool("Check", false);
        _anim.SetBool("DashAt", false);
        _test = false;
    }
}