using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly : MonoBehaviour
{
    private GameObject _player;
    private float _speed = 8f;
    private Rigidbody2D _rb2d;

    void Start()
    {
        _player = GameObject.Find("Player");
        _rb2d = GetComponent<Rigidbody2D>();
        if (_player.transform.localScale.x > 0)
        {
            _rb2d.velocity = Vector2.right * _speed;
        }
        else
        {
            transform.localScale = new Vector2(-1, 1);
            _rb2d.velocity = Vector2.left * _speed;
        }
    }
    void Update()
    {
        Destroy(this.gameObject, 3f);
    }
}
