using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool jump, isJumping, gameOver;
    private float movePlayer;
    private GameObject inicialPos, mainCamera, limiteCam, limiteCamMin;
    private int score;

    public GameObject painel;
    public Text scoreTxt;
    public int speed, jumpForce;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        isJumping = false;
        gameOver = false;
        inicialPos = GameObject.Find("InicialPos");
        mainCamera = GameObject.Find("MainCamera");
        limiteCam = GameObject.Find("limiteCam");
        limiteCamMin = GameObject.Find("limiteCamMin");

        // mostra pontuação
        score = PlayerPrefs.GetInt("totalScore");
        scoreTxt.text = score.ToString();
    }

    void Update()
    {
        Move();
        Jump();
        GameOver();
        CamFollowPlayer();
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
            PlayerPrefs.SetInt("totalScore", score);
            PlayerPrefs.Save();
        }
        if (collision.CompareTag("Coin"))
        {
            score++;
            scoreTxt.text = score.ToString();
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
            mainCamera.transform.position = new Vector3(mainCamera.transform.position.x,rb.position.y+2, mainCamera.transform.position.z);
            gameOver = false;
        }
    }
    private void CamFollowPlayer()
    {
        if (rb.position.y > limiteCam.transform.position.y)
        {
            mainCamera.transform.position = new Vector3(mainCamera.transform.position.x, mainCamera.transform.position.y + 0.05f, mainCamera.transform.position.z);
        }
        else if (rb.position.y < limiteCamMin.transform.position.y)
        {
            mainCamera.transform.position = new Vector3(mainCamera.transform.position.x, mainCamera.transform.position.y - 0.05f, mainCamera.transform.position.z);
        }
    }
}
