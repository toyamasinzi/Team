using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchDisable : MonoBehaviour
{
    [SerializeField] Animator _Animator;
    [SerializeField] string _animStateName;
    private void OnDisable()
    {
        if (gameObject.tag == "Finish")
        {
            _Animator.Play(_animStateName);
        }
    }
}
