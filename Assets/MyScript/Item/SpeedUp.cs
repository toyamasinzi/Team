using UnityEngine;

public class SpeedUp :Item
{
    [SerializeField] float _sp = 6f;
    public override void Activate()
    {
        FindObjectOfType<Player>().Speed(_sp);
    }
}
