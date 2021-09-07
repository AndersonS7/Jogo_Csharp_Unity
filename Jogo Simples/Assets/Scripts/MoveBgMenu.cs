using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBgMenu : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject[] points;
    public float time;
    public float speed;
    private Vector3 nextPoint;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        nextPoint = points[0].transform.position;
    }

    void Update()
    {
        MoveBg();
    }

    void MoveBg()
    {
        time = time + Time.deltaTime;

        if (time >= 3)
        {
            int x = Random.Range(0, points.Length);
            nextPoint = points[x].transform.position;
            time = 0;
        }
        transform.position = Vector3.MoveTowards(transform.position, nextPoint, speed * Time.deltaTime);
    }
}
