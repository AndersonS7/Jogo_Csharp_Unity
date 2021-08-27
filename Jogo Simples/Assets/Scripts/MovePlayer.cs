using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool jump, isJumping, gameOver;
    private float movePlayer;
    private GameObject inicialPos, mainCamera, limiteCam;
    private Vector3 initialPosCam;
    
    public GameObject painel;
    public int speed, jumpForce;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        isJumping = false;
        gameOver = false;
        inicialPos = GameObject.Find("InicialPos");
        mainCamera = GameObject.Find("MainCamera");
        limiteCam = GameObject.Find("limiteCam");
        initialPosCam = mainCamera.transform.position;
    }

    void Update()
    {
        Move();
        Jump();
        GameOver();
        CheckCamPosition();
    }

    // métodos unity
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "plataforma")
        {
            isJumping = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("armadilhas"))
        {
            gameOver = true;
        }
        if (collision.CompareTag("win"))
        {
            painel.SetActive(true);
            speed = 0;
            jumpForce = 0;
        }
    }
    
    // métodos próprios
    public void Move()
    {
        movePlayer = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(movePlayer * speed, rb.velocity.y);
    }
    public void Jump()
    {
        jump = Input.GetButtonDown("Jump");
        if (jump && isJumping == false)
        {
            isJumping = true;
            rb.AddForce(new Vector2(0, jumpForce));
        }
    }
    private void GameOver()
    {
        if (gameOver)
        {
            rb.position = inicialPos.transform.position;
            gameOver = false;
        }
    }
    private void CamFollowPlayer()
    {
        mainCamera.transform.position = new Vector3(mainCamera.transform.position.x, rb.position.y, mainCamera.transform.position.z);
    }
    private void CheckCamPosition()
    {
        if (rb.position.y > limiteCam.transform.position.y)
        {
            CamFollowPlayer();
        }
        else
        {
            mainCamera.transform.position = initialPosCam;
        }
    }
}
