using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyAi : MonoBehaviour
{
    public float speed;
    public float isolationWaitTime;


    private float waitTime;
    public float startWaitTime;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;
    private bool isInIsolation = false;

    public Vector2 wayPoint;

    // Start is called before the first frame update
    void Start()
    {
        SetNewDestination();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, wayPoint, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, wayPoint) < 0.2f)
        {
            if (isInIsolation) 
            {
                Destroy(gameObject);
            }
            if (waitTime <= 0) 
            {
                SetNewDestination();
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
        waitTime = startWaitTime;
    }

    public void SetIsolationDestination()
    {
        wayPoint = new Vector2(Random.Range(maxX + 1f, maxX + 2f), Random.Range(maxY + 1f, maxY + 2f));
        waitTime = isolationWaitTime;
        isInIsolation = true;
    }
}
