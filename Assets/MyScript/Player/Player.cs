using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player: MonoBehaviour
{
    [SerializeField] float speed = 0f;
    [SerializeField] float jumpPower = 15f;
    [SerializeField] float time = 0f;
    [SerializeField] float count = 3f;
    [SerializeField] GameObject player1;
    [SerializeField] GameObject player2;
    [SerializeField] GameObject camera1;
    [SerializeField] GameObject camera2;
    float h = 0f;

    private int jumpCount = 0;
    private Rigidbody2D rb2d; 
    private Vector2 dir = new Vector2(0, 0);

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        player2.transform.position = player1.transform.position;
        time += Time.deltaTime;
        h = Input.GetAxisRaw("Horizontal");
        Vector2 dir = new Vector2(h, 0);
        Vector2 b = dir.normalized * speed;
        b.y = rb2d.velocity.y;
        rb2d.velocity = b;

        if (Input.GetKey("q") && time > count)
        { 
            player2.SetActive(true);
            player1.SetActive(false);
            camera2.SetActive(true);
            camera1.SetActive(false);
            time = 0;
        }
        if(Input.GetButtonDown("Jump") && jumpCountÅ@< 2)
        {
            rb2d.velocity = Vector2.zero;
            rb2d.AddForce(transform.up * jumpPower, ForceMode2D.Impulse);
            jumpCount++;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            
            jumpCount = 0;
        }
    }
}