using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool jump, isJumping;
    public static bool won, gameOver, wasCollected;
    private float movePlayer;
    private GameObject mainCamera, limiteCam, limiteCamMin;
    private int score;
    private Vector3 initialPos;

    public Text scoreTxt;
    public int speed, jumpForce;

    // animações
    public Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
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
            animator.SetBool("isJump", false);
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
            wasCollected = true;
        }
    }

    // métodos próprios
    public void Move()
    {
        movePlayer = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(movePlayer * speed, rb.velocity.y);

        // virar lado
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            transform.localScale = new Vector2(0.2f, transform.localScale.y);
        }
        else if(Input.GetAxisRaw("Horizontal") < 0)
        {
            transform.localScale = new Vector2(-0.2f, transform.localScale.y);
        }

        // animação andando 
        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            animator.SetBool("isRun", true);
        }
        else
        {
            animator.SetBool("isRun", false);
        }
    }
    public void Jump()
    {
        jump = Input.GetButtonDown("Jump");
        if (jump && !isJumping)
        {
            isJumping = true;
            rb.AddForce(new Vector2(0, jumpForce));
            animator.SetBool("isJump", true);
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

        // salva o valor da fase que foi completada
        if (SceneManager.GetActiveScene().buildIndex > PlayerPrefs.GetInt("faseCompletada"))
        {
            PlayerPrefs.SetInt("faseCompletada", SceneManager.GetActiveScene().buildIndex);
            PlayerPrefs.Save();
        }
    }
    private void GameOver()
    {
        if (gameOver)
        {
            transform.position = initialPos;
            gameOver = false;
        }
    }
}
