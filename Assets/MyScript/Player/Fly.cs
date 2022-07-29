using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly : MonoBehaviour
{
    float _speed = 8f;
    Rigidbody2D _rb2d;
    [SerializeField] GameObject _player;
    void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (_player.transform.localScale.x > 0)
        {
           _rb2d.velocity = Vector2.right * _speed;
        }
        else
        {
            _rb2d.velocity = Vector2.left * _speed;
        }
        Destroy(this.gameObject, 3f);
    }
}
