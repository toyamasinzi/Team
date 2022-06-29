using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour,IDamegable
{
    [SerializeField] GameObject _player1;//�I�u�W�F�N�g���Q�Ƃ���
    [SerializeField] GameObject _player2;
    [SerializeField] float _speed = 1f;
    [SerializeField] int _enemyHP = 3;
    [SerializeField] int _attackPower = 1;

    private void OnTriggerStay2D(Collider2D collision)
    {
        //�ʂ̃X�N���v�g�ŏ���
        if (collision.gameObject.tag == "Player" && _player1 == true)
        {
            Vector2 targeting = (_player1.transform.position - this.transform.position).normalized;//�v���C���[-�G�L�����̈ʒu�֌W����������擾���A���x����艻
            this.GetComponent<Rigidbody2D>().velocity = new Vector2((targeting.x * _speed), 0);//�v���C���[�ǂ�
        }

        if(collision.gameObject.tag == "Player2" && _player2 == true)
        {
            Vector2 target = (_player2.transform.position - this.transform.position).normalized;//�v���C���[-�G�L�����̈ʒu�֌W����������擾���A���x����艻
            this.GetComponent<Rigidbody2D>().velocity = new Vector2((target.x * _speed), 0);//�v���C���[�ǂ�
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            IDamegable player = collision.gameObject.GetComponent<IDamegable>();
            if(player != null)
            {
                player.Damage(_attackPower);
            }
        }
    }
    public void Damage(int attackPower)
    {
        _enemyHP -= attackPower;
        if (_enemyHP <= 0)
        {
            this.gameObject.SetActive(false);
        }
    }

}
