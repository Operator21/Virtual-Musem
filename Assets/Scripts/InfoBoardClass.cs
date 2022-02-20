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
    public UnityEvent Activate;
    public UnityEvent Deactivate;
    public UnityEvent Hide;
    public UnityEvent Show;
    private GameObject player;
    void Start(){
        headerMesh.text = headerText;
        contentMesh.text = contentText;
        player = GameObject.FindGameObjectWithTag("Player");
    }
    
    void Update(){
        Vector3 newPosition = mainObject.transform.position;
        newPosition.y = heightFromObject;
        transform.SetPositionAndRotation(newPosition, new Quaternion());
        transform.rotation = Quaternion.LookRotation(transform.position - player.transform.position);
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.Equals(player))
            Activate.Invoke();
    }

    private void OnTriggerExit(Collider other) {
        if(other.gameObject.Equals(player))
            Deactivate.Invoke();
    }
}
