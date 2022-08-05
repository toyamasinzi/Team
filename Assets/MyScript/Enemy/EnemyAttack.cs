using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] Transform _centerPos; //レイのセンターポジション
    [SerializeField] LayerMask _playerMask = 3;//プレイヤーの当たり判定
    [SerializeField] GameObject _col;//攻撃の当たり判定
    [SerializeField] Animator _anim;//再生したいアニメ－ター
    [SerializeField] float _radius = 1f;//レイの半径
    [SerializeField] string _animStateName;//アニメーションの名前
    [SerializeField] float _ct;//_colのクールタイム
    [SerializeField] float _timer = 0f;//クールタイムの時間

    private void Start()
    {
        if (_centerPos == null  || _col == null || _anim == null)
        {
            Debug.LogError("参照を確認");
        }
    }
    void Update()
    {
        _timer += Time.deltaTime;

        if (InSight())
        {
            if (_timer > _ct)
            {
                _anim.Play(_animStateName);
                _timer = 0f;
                _col.SetActive(true);
            }
        }
    }
    /// <summary>
    /// レイ
    /// </summary>
    /// <returns></returns>
    bool InSight()
    {
        Vector2 center = _centerPos.position;
        bool _inSight = Physics2D.CircleCast(center, _radius, Vector2.left, 0, _playerMask);//始点、半径　方向　距離　オブジェクトレイヤー
        return _inSight;
    }

    /// <summary>
    /// レイを可視化するための色
    /// </summary>
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_centerPos.position, _radius);
    }
    /// <summary>
    /// アニメーションイベント
    /// </summary>
    public void StartAt()
    {
        _col.SetActive(false);
    }
}

