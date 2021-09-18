using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveParede : MonoBehaviour
{
    public int speed;
    public GameObject ponto1, ponto2;
    public Vector3 nextPos;

    void Start()
    {
        nextPos = ponto2.transform.position;
        transform.position = ponto1.transform.position;

    }

    void Update()
    {
        MoveTrap();
    }

    private void MoveTrap()
    {
        if (transform.position == ponto1.transform.position)
        {
            nextPos = ponto2.transform.position;
        }else if (transform.position == ponto2.transform.position)
        {
            nextPos = ponto1.transform.position;
        }

        transform.position = Vector3.MoveTowards(transform.position, nextPos, speed * Time.deltaTime);
    }
}
