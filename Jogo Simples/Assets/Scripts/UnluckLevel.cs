using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class UnluckLevel : MonoBehaviour
{

    public Button[] leveis;

    void Update()
    {
        UlkLevel();
    }

    public void UlkLevel()
    {
        for (int i = 0; i < leveis.Length; i++)
        {
            if (i + 2 > PlayerPrefs.GetInt("faseCompletada"))
            {
                leveis[i].interactable = false;
            }
        }
    }
}
