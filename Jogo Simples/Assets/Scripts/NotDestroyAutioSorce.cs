using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotDestroyAutioSorce : MonoBehaviour
{
    private static NotDestroyAutioSorce instance = null;

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(gameObject);
    }
}
