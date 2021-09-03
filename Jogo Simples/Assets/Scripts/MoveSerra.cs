using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSerra : MonoBehaviour
{
    private float z;
    private Vector3 nextPos;
    public int speed;
    public GameObject ponto01, ponto02;


    void Start()
    {
        transform.position = ponto01.transform.position;
        nextPos = ponto01.transform.position;
    }

    void Update()
    {
        RotationTrap();
        MoveTrap(); 
    }

    void RotationTrap()
    {
        z = z + Time.deltaTime * 100;
        transform.rotation = Quaternion.Euler(0,0,z);
    }

    void MoveTrap()
    {
        if (transform.position == ponto01.transform.position)
        {
            nextPos = ponto02.transform.position;
        }
        else if (transform.position == ponto02.transform.position)
        {
            nextPos = ponto01.transform.position;
        }

        transform.position = Vector3.MoveTowards(transform.position, nextPos, speed * Time.deltaTime);
    }
}
