using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] GameObject[] waypoints;
    int ValueNum = 0;

    [SerializeField] float speed = 1f;


    void Update()
    {
        if (Vector3.Distance(transform.position, waypoints[ValueNum].transform.position) < .1f)
        {
            ValueNum++;
            if (ValueNum >= waypoints.Length)
            {
                ValueNum = 0;
            }
        }

        transform.position = Vector3.MoveTowards(transform.position, waypoints[ValueNum].transform.position, speed * Time.deltaTime);
    }
}
