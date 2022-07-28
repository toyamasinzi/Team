using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] Transform _centerPos = default;
    [SerializeField] LayerMask _playerMask = 3;
    [SerializeField] float _radius = 2;

    private Animator _anim;
    private float _ct = 0f;

    void Start()
    {
        _anim = GetComponent<Animator>();
    }

    void Update()
    {
        _ct += Time.deltaTime;
        Debug.Log(_playerMask.value);
        if (InSight())
        {
            if (_ct > 2)
            {
                _anim.Play("Enemy1_Attack");
                _ct = 0f;
            }
            else
            {

            }
        }
    }
        bool InSight()
        {
            Vector2 center = _centerPos.position;
            bool inSight = Physics2D.CircleCast(center, _radius, Vector2.left, 0f, _playerMask);//始点、半径　方向　距離　オブジェクトレイヤー
            return inSight;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(_centerPos.position, _radius);
        }
    }

