using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    [SerializeField] Animator _Animator;
    [SerializeField] string animStateName;
    private void OnTriggerEnter2D(Collider2D collision) //�R���C�_�[���g���K�[�������甽������
    {
        /*if (collision.gameObject.tag == "Player" || collision.transform.tag == "Player2")//�v���C���[�P�܂��̓v���C���[�Q
        {
            _time += Time.deltaTime;
            _Animator.Play(animStateName);//�A�j���[�V�������Đ�����
            camera.SetActive(true);

            if(_time > _count)
            {
                camera.SetActive(false);
            }
        }*/
    }
    private void OnDisable()
    {
        if (gameObject.tag == "Finish")//�v���C���[�P�܂��̓v���C���[�Q
        {
            _Animator.Play(animStateName);//�A�j���[�V�������Đ�����

            /*   if (_time > _count)
               {
                   camera.SetActive(false);
               }
           */
        }
    }
}
