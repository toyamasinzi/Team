using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public abstract class Item : MonoBehaviour
{
    [SerializeField] AudioClip _se = default;

    public abstract void Activate();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Player2")
        {
            AudioSource.PlayClipAtPoint(_se, Camera.main.transform.position);

            Activate();

            Destroy(gameObject);
        }
    }
}
