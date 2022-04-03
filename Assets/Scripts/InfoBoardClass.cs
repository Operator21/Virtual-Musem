using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class InfoBoardClass : MonoBehaviour
{
    public string headerText;
    [TextArea(3, 10)]
    public string contentText;
    public GameObject mainObject;
    public TextMeshProUGUI headerMesh;
    public TextMeshProUGUI contentMesh;
    public TextMeshProUGUI indicatorMesh;
    [Range(0,10)]
    public float heightFromObject;
    [Space]
    [Range(3,20)]
    public float hideTextDistance = 5;
    public Color indicatorColor = new Color(0, 255, 17);
    [Space]
    public UnityEvent Activate;
    public UnityEvent Deactivate;
    public UnityEvent Hide;
    public UnityEvent Show;
    private GameObject player;
    private GameObject mainCamera;
    private float distance;
    
    void Start(){
        headerMesh.text = headerText;
        contentMesh.text = contentText;
        player = GameObject.FindGameObjectWithTag("Player");
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        transform.Find("Indicator").GetComponent<TextMeshProUGUI>().color = indicatorColor;
    }
    
    void Update(){
        Vector3 newPosition = mainObject.transform.position;
        newPosition.y = heightFromObject;
        transform.position = newPosition;
        distance = Vector3.Distance(gameObject.transform.position, mainCamera.transform.position);  
        if(distance > 1)
            Show.Invoke();
            if(distance > hideTextDistance)
                Deactivate.Invoke();
            if(distance <= hideTextDistance)
                Activate.Invoke();
        if(distance < 0.8f)
            Hide.Invoke();       
    }

    /*private void OnTriggerEnter(Collider other) {
        //Debug.Log("Entered collision field");
        //Debug.Log(other.gameObject.name);
        if(other.gameObject.Equals(player))
            Activate.Invoke();
    }

    private void OnTriggerExit(Collider other) {
        //Debug.Log("Left collision field");
        //Debug.Log(other.gameObject.name);
        if(other.gameObject.Equals(player))
            Deactivate.Invoke();
    }*/
}
