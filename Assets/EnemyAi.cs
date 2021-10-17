using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyAi : MonoBehaviour
{
    public float speed;

    private float waitTime;
    public float startWaitTime;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    Vector2 wayPoint;



    // Start is called before the first frame update
    void Start()
    {
        SetNewDestination();
        waitTime = startWaitTime;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, wayPoint, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, wayPoint) < 0.2f)
        {
            if (waitTime <= 0) 
            {
                SetNewDestination();
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }

    void SetNewDestination() 
    { 
        wayPoint = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
    }
}
