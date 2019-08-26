using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    public float left;
    public float right;
    private float jumpPower = 1200f;
    protected static Rigidbody2D rb;

    private int jumpCount;

    // Start is called before the first frame update
    private void Start()
    {
        jumpCount = 2;

    }

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(new Vector2(left, 0.0f) * Time.deltaTime);
            transform.localScale = new Vector2(-1, 1);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(new Vector2(right, 0.0f) * Time.deltaTime);
            transform.localScale = new Vector2(1, 1);
        }

        if (Input.GetKeyDown(KeyCode.R)) //다시 시작
        {
            SceneManager.LoadScene("Tutorial");
        }

        if (jumpCount > 0) //2단 점프
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                if (jumpCount == 2)
                {
                    rb.AddForce(Vector2.up * jumpPower);
                    rb.velocity = Vector3.zero;
                    jumpCount -= 1;
                }
                else if (jumpCount == 1)
                {
                    rb.AddForce(Vector2.up * (jumpPower - 150f)); //두번째 점프는 첫번째보단 낮음
                    rb.velocity = Vector3.zero;
                    jumpCount -= 1;
                }
            }
        }
        Vector3 worldpos = Camera.main.WorldToViewportPoint(this.transform.position);
        if (worldpos.x < 0f) worldpos.x = 0f;
        if (worldpos.x > 1f) worldpos.x = 1f;
        this.transform.position = Camera.main.ViewportToWorldPoint(worldpos);
    }

    void OnCollisionEnter2D(Collision2D col) //점프 횟수 초기화
    {
        if (col.gameObject.CompareTag("Ground"))
        {
            jumpCount = 2; //Ground에 닿으면 점프횟수가 1로 초기화됨
        }

        if (col.gameObject.CompareTag("Monster"))
        {
            SceneManager.LoadScene("Tutorial");
        }
    }
}
