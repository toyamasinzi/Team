using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyEnemyMove : MonoBehaviour
{
    [SerializeField] GameObject _player1 = default;
    [SerializeField] float _speed = 3f;

    private Animator _anim;


    void Start()
    {
        _anim = GetComponent<Animator>();
    }
    private void Update()
    {
       _anim.SetBool("move", false);
    }
    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _anim.SetBool("move", true);
            Vector3 targeting = (_player1.transform.position - transform.position).normalized;
            transform.LookAt(_player1.transform);
            transform.position += transform.forward * _speed;
            if (targeting.x > 0)
            {
                transform.rotation = new Quaternion(0, 1f, 0, 0);
            }
            else
            {
                transform.rotation = new Quaternion(0, 0, 0, 0);
            }
        }
    }
}

