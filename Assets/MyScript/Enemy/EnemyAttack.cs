using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] Transform _centerPos = default;
    [SerializeField] LayerMask _playerMask = 3;
    [SerializeField] float _radius = 1;
    [SerializeField] GameObject _col;

    private Animator _anim;
    private float _ct = 0f;

    void Start()
    {
        _anim = GetComponent<Animator>();
    }

    void Update()
    {
        _ct += Time.deltaTime;
        if (InSight())
        {
            if (_ct > 2)
            {
                _anim.Play("Enemy1_Attack");
                _ct = 0f;
                _col.SetActive(true);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(gameObject.tag == "Player" || gameObject.tag == "Player2")
        {
            Debug.Log("a");
        }
    }
    public void StartAt()
    {
        _col.SetActive(false);
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

