using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly : MonoBehaviour
{
    float _speed = 8f;
    Rigidbody2D _rb2d;
    void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        _rb2d.velocity = Vector2.right * _speed;
        Destroy(this.gameObject, 3f);
    }
}
