using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    [SerializeField] Animator _Animator;
    [SerializeField] string animStateName;
    private void OnTriggerEnter2D(Collider2D collision) //コライダーがトリガーだったら反応する
    {
        /*if (collision.gameObject.tag == "Player" || collision.transform.tag == "Player2")//プレイヤー１またはプレイヤー２
        {
            _time += Time.deltaTime;
            _Animator.Play(animStateName);//アニメーションを再生する
            camera.SetActive(true);

            if(_time > _count)
            {
                camera.SetActive(false);
            }
        }*/
    }
    private void OnDisable()
    {
        if (gameObject.tag == "Finish")//プレイヤー１またはプレイヤー２
        {
            _Animator.Play(animStateName);//アニメーションを再生する

            /*   if (_time > _count)
               {
                   camera.SetActive(false);
               }
           */
        }
    }
}
