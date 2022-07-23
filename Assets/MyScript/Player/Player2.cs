using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    [SerializeField] float _speed;//‘¬“x
    [SerializeField] float _jumpPower = 15f;
    [SerializeField] float _count = 3f;
    [SerializeField] float _time = 0f;
    [SerializeField] GameObject _player1;
    [SerializeField] GameObject _camera1;
    [SerializeField] GameObject _camera2;

    private int _jumpCount = 0;
    private Rigidbody2D _rb2d;
    private Vector2 _dir = new Vector2(0, 0);
    private float _xSpeed = 0f;
    private Animator _anim;
    private float _h = 0f;
    public GroundChecck _Ground;
    private float _ct = 0f;

    void Start()
    {
        _Ground = GetComponentInChildren<GroundChecck>();
        _anim = GetComponent<Animator>();
        _rb2d = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        _ct += Time.deltaTime;
        _player1.transform.position = gameObject.transform.position;
        _time += Time.deltaTime;
        _h = Input.GetAxisRaw("Horizontal");
        if (_h > 0)

        {
            transform.localScale = new Vector2(1, 1);
            _anim.SetFloat("Move1", 1f);
            _xSpeed = _speed;
        }
        else if (_h < 0)
        {
            transform.localScale = new Vector2(-1, 1);
            _anim.SetFloat("Move1", 1f);
            _xSpeed = -_speed;

        }
        else
        {
            _anim.SetFloat("Move1", 0.1f);
            _xSpeed = 0f;
        }
        if (_rb2d.velocity.y < 0 && _Ground._groundCheck)
        {
            Debug.Log("2");
            _anim.SetFloat("JumpMove", 1f);
            _anim.SetBool("Jump", true);
        }
        Vector2 dir = new Vector2(_h, 0);
        Vector2 b = dir.normalized * _speed;
        b.y = _rb2d.velocity.y;
        _rb2d.velocity = b;

        if (Input.GetKey("q") && _time > _count && _ct > 0.4)
        {
            _player1.SetActive(true);
            gameObject.SetActive(false);
            _camera1.SetActive(true);
            _camera2.SetActive(false);
            _time = 0;
        }
        if (Input.GetButtonDown("Jump") && _jumpCount < 1)
        {
            _rb2d.velocity = Vector2.zero;
            _rb2d.AddForce(transform.up * _jumpPower, ForceMode2D.Impulse);
            if (_rb2d.velocity.y > 0)
            {
                Debug.Log("1");
                _anim.SetFloat("JumpMove", 0f);
                _anim.SetBool("Jump", true);
            }
            _jumpCount++;
            _ct = 0;
        }
        if (Input.GetButtonDown("Fire1") && _ct > 0.4)
        {
            _anim.Play("Attack1");
            _ct = 0;
        }
        if (Input.GetButtonDown("Fire2") && _ct > 0.4)
        {
            _anim.Play("GunAttack");
            _ct = 0;
        }
        if(Input.GetButtonDown("Fire3") && _ct > 0.4)
        {
            _anim.Play("Guard");
            _ct = 0;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            _jumpCount = 0;
            _anim.SetBool("Jump", false);
        }
    }
}
