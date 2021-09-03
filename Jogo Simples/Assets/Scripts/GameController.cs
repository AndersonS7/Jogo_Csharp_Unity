using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private void Start()
    {

    }
    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void ChooseLevel()
    {
        SceneManager.LoadScene("Level");
    }
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
}
