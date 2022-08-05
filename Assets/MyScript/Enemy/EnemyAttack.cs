using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] Transform _centerPos; //���C�̃Z���^�[�|�W�V����
    [SerializeField] LayerMask _playerMask = 3;//�v���C���[�̓����蔻��
    [SerializeField] GameObject _col;//�U���̓����蔻��
    [SerializeField] Animator _anim;//�Đ��������A�j���|�^�[
    [SerializeField] float _radius = 1f;//���C�̔��a
    [SerializeField] string _animStateName;//�A�j���[�V�����̖��O
    [SerializeField] float _ct;//_col�̃N�[���^�C��
    [SerializeField] float _timer = 0f;//�N�[���^�C���̎���

    private void Start()
    {
        if (_centerPos == null  || _col == null || _anim == null)
        {
            Debug.LogError("�Q�Ƃ��m�F");
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
    /// ���C
    /// </summary>
    /// <returns></returns>
    bool InSight()
    {
        Vector2 center = _centerPos.position;
        bool _inSight = Physics2D.CircleCast(center, _radius, Vector2.left, 0, _playerMask);//�n�_�A���a�@�����@�����@�I�u�W�F�N�g���C���[
        return _inSight;
    }

    /// <summary>
    /// ���C���������邽�߂̐F
    /// </summary>
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_centerPos.position, _radius);
    }
    /// <summary>
    /// �A�j���[�V�����C�x���g
    /// </summary>
    public void StartAt()
    {
        _col.SetActive(false);
    }
}

