using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject player1;//オブジェクトを参照する
    [SerializeField] GameObject player2;
    [SerializeField] float speed = 1f;

    void FixedUpdate()
    {
        if (player1 == true)
        {
            Vector2 targeting = (player1.transform.position - this.transform.position).normalized;//プレイヤー-敵キャラの位置関係から方向を取得し、速度を一定化
            this.GetComponent<Rigidbody2D>().velocity = new Vector2((targeting.x * speed), 0);//プレイヤー追う
        }
        if (player2 == true)
        {
            Vector2 target = (player2.transform.position - this.transform.position).normalized;//プレイヤー-敵キャラの位置関係から方向を取得し、速度を一定化
            this.GetComponent<Rigidbody2D>().velocity = new Vector2((target.x * speed), 0);//プレイヤー追う
        }
    }
}
