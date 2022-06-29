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
    float h = 0f;

    private int _jumpCount = 0;
    private Rigidbody2D _rb2d;
    private Vector2 _dir = new Vector2(0, 0);

    void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        _player1.transform.position = gameObject.transform.position;
        _time += Time.deltaTime;
        h = Input.GetAxisRaw("Horizontal");
        Vector2 dir = new Vector2(h, 0);
        Vector2 b = dir.normalized * _speed;
        b.y = _rb2d.velocity.y;
        _rb2d.velocity = b;

        if (Input.GetKey("q") && _time > _count)
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
            _jumpCount++;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            _jumpCount = 0;
        }
    }
}