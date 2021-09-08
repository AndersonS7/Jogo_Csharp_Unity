using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject player, panel;
    private int CurrentScene;

    private void Update()
    {
        WinControll();
        MenuWin();
    }

    // ==========*=============*=======
    #region Fases
    public void Fase1()
    {
        SceneManager.LoadScene("Fase_01");
    }
    public void Fase2()
    {
        SceneManager.LoadScene("Fase_02");
    }
    public void Fase3()
    {
        SceneManager.LoadScene("Fase_03");
    }
    public void Fase4()
    {
        SceneManager.LoadScene("Fase_04");
    }
    #endregion
    public void Play()
    {
        int CurrentL = PlayerPrefs.GetInt("faseCompletada");
        if (CurrentL < 2)
        {
            SceneManager.LoadScene(2);
        }
        else
        {
            SceneManager.LoadScene(CurrentL + 1);
        }
    }
    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void ChooseLevel()
    {
        SceneManager.LoadScene("Level");
    }
    public void ResetScore()
    {
        PlayerPrefs.DeleteKey("totalScore");
        PlayerPrefs.DeleteKey("faseCompletada");
    }
    public void Config()
    {
        SceneManager.LoadScene("Config");
    }
    public void NextFase()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void WinControll()
    {
        if (MovePlayer.won)
        {
            CurrentScene = SceneManager.GetActiveScene().buildIndex;

            if (CurrentScene > 1 && CurrentScene < 6)
            {
                SceneManager.LoadScene(CurrentScene + 1);
            }
        }
    }
    public void MenuWin()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Home))
        {
            panel.SetActive(true);
        }
    }
    public void ExitPanel()
    {
        panel.SetActive(false);
    }
}
