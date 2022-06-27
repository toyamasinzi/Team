using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject player1;//�I�u�W�F�N�g���Q�Ƃ���
    [SerializeField] GameObject player2;
    [SerializeField] float speed = 1f;

    void FixedUpdate()
    {
        if (player1 == true)
        {
            Vector2 targeting = (player1.transform.position - this.transform.position).normalized;//�v���C���[-�G�L�����̈ʒu�֌W����������擾���A���x����艻
            this.GetComponent<Rigidbody2D>().velocity = new Vector2((targeting.x * speed), 0);//�v���C���[�ǂ�
        }
        if (player2 == true)
        {
            Vector2 target = (player2.transform.position - this.transform.position).normalized;//�v���C���[-�G�L�����̈ʒu�֌W����������擾���A���x����艻
            this.GetComponent<Rigidbody2D>().velocity = new Vector2((target.x * speed), 0);//�v���C���[�ǂ�
        }
    }
}
