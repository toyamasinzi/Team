using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCollider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
            Debug.Log("1");
    }

  /*  public void ColliderSettrue()
    {
        .SetActive(true);
    }
    public void ColliderSetfalse()
    {
        .SetActive(false);
    }*/
}
