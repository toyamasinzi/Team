using UnityEngine;

public class DeleteItem : Item
{
    [SerializeField] GameObject _oj;
    public override void Activate()
    {
        _oj.SetActive(false);
    }
}
