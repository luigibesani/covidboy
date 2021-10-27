using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCLeaveCoroutine : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StopShopping());
    }

    IEnumerator StopShopping()
    {
        yield return new WaitForSeconds(15f);
        gameObject.GetComponent<EnemyAi>().SetIsolationDestination();
    }
}
