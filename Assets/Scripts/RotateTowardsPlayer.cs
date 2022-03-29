using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTowardsPlayer : MonoBehaviour
{
    Vector3 playerPosition;
    void Update()
    {
        playerPosition = GameObject.FindGameObjectWithTag("MainCamera").transform.position;
        transform.rotation = Quaternion.LookRotation(transform.position - playerPosition);
    }
}
