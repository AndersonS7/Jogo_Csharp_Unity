using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool jump, isJumping;
    public static bool won, gameOver;
    private float movePlayer, timeToBeReborn;
    private GameObject mainCamera, limiteCam, limiteCamMin;
    private int score;
    private Vector3 initialPos;

    public Text scoreTxt;
    public int speed, jumpForce;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        isJumping = false;
        gameOver = false;
        won = false;
        mainCamera = GameObject.Find("MainCamera");
        limiteCam = GameObject.Find("limiteCam");
        limiteCamMin = GameObject.Find("limiteCamMin");
        initialPos = GameObject.Find("InicialPos").transform.position;

        // mostra pontuação
        score = PlayerPrefs.GetInt("totalScore");
        scoreTxt.text = score.ToString();
    }

    void Update()
    {
        Move();
        Jump();
        CamFollowPlayer();
        GameOver();
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
            Win();
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
        if (jump && !isJumping)
        {
            isJumping = true;
            rb.AddForce(new Vector2(0, jumpForce));
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
    private void Win()
    {
        won = true;
        speed = 0;
        jumpForce = 0;
        PlayerPrefs.SetInt("totalScore", score);
        PlayerPrefs.Save();
    }
    private void GameOver()
    {
        if (gameOver)
        {
            speed = 0;
            jumpForce = 0;
            transform.position = initialPos;
            //mainCamera.transform.position = new Vector3(mainCamera.transform.position.x,rb.position.y+2, mainCamera.transform.position.z);
            ResetSkills();
        }
    }
    private void ResetSkills()
    {
        if (gameOver)
        {
            timeToBeReborn = timeToBeReborn + Time.deltaTime;
            if (timeToBeReborn >= 1.5f)
            {
                speed = 3;
                jumpForce = 350;
                gameOver = false;
                timeToBeReborn = 0;
            }
        }
    }
}
