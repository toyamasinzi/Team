using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float _speed = 0f;
    [SerializeField] float _jumpPower = 15f;
    [SerializeField] float _time = 0f;
    [SerializeField] GameObject _player2;
    [SerializeField] GameObject _camera1;
    [SerializeField] GameObject _camera2;
    [SerializeField] private string[] _nlAttacks = { "AT1", "AT2", "AT3" };

    private float _count = 3f;
    private float _xSpeed = 0f;
    private Animator _anim;
    private float _h = 0f;
    private int _jumpCount = 0;
    private Rigidbody2D _rb2d;
    private Vector2 _dir = new Vector2(0, 0);
    private int _attackCount = 0;
    private bool _attackNow = false;
    private bool _fastInput = false;
    public GroundChecck _Ground;
    public float _ct = 0f;
    void Start()
    {
        _Ground = GetComponentInChildren<GroundChecck>();
        _anim = GetComponent<Animator>();
        _rb2d = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        _ct += Time.deltaTime;
        _player2.transform.position = gameObject.transform.position;
        _time += Time.deltaTime;
        _h = Input.GetAxisRaw("Horizontal");
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
            _xSpeed = -_speed;

        }
        else
        {
            _anim.SetFloat("Move", 0.1f);
            _xSpeed = 0f;
        }
        if (_rb2d.velocity.y < 0 && _Ground._groundCheck)
        {
            _anim.SetFloat("JumpMove", 1f);
            _anim.SetBool("Jump", true);
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
        if (Input.GetButtonDown("Jump") && _jumpCount < 2)
        {
            _rb2d.velocity = Vector2.zero;
            _rb2d.AddForce(transform.up * _jumpPower, ForceMode2D.Impulse);
            if (_rb2d.velocity.y > 0)
            {
                _anim.SetFloat("JumpMove", 0f);
                _anim.SetBool("Jump", true);
            }
            _jumpCount++;

        }
        if (Input.GetButtonDown("Fire1"))
        {
            if (_attackCount >= _nlAttacks.Length)
            {
                return;
            }
            if (_attackNow)
            {
                if (_fastInput)
                {
                    _fastInput = false;
                }
                return;
            }
            _attackNow = true;
            _fastInput = true;
            _anim.Play(_nlAttacks[_attackCount]);
            _attackCount++;
            _ct = 0;
        }
        if (Input.GetButtonDown("Fire2"))
        {
            _anim.Play("Player1_DashAttack");
            _ct = 0;
        }
        if (Input.GetButtonDown("Fire3"))
        {
            _anim.Play("Player1_Avoid");
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
    public void Speed(float _sp)
    {
        _speed += _sp;
    }
    private void AttackReset()
    {
        if (_fastInput || _attackCount >= _nlAttacks.Length)
        {
            _attackCount = 0;
            _fastInput = false;
            _attackNow = false;
            return;
        }
        _anim.Play(_nlAttacks[_attackCount]);
        _attackCount++;
        _fastInput = true;
    }
}