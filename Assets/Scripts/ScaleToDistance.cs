using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleToDistance : MonoBehaviour
{
    [Range(0.1f, 5)]
    public float maxScale = 1f;
    [Range(0.1f, 5)]
    public float minScale = 0.2f;
    [Range(0.1f, 5)]
    public float step = 2;
    public bool rotateTowardsPlayer = true;
    void Update() {
        Vector3 playerPosition = GameObject.FindGameObjectWithTag("MainCamera").transform.position;
        float distance = Vector3.Distance(gameObject.transform.position, playerPosition);
        //Debug.Log(distance);
        gameObject.transform.localScale = new Vector3(
            Mathf.Clamp(distance/step, minScale, maxScale),
            Mathf.Clamp(distance/step, minScale, maxScale),
            Mathf.Clamp(distance/step, minScale, maxScale)
        );
        if(rotateTowardsPlayer)
            transform.rotation = Quaternion.LookRotation(transform.position - playerPosition);
    }
}
