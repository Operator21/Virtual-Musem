using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public enum _navigationType {
    Next,
    Previous
}
public class ChangePage : MonoBehaviour
{
    public TextMeshProUGUI textMesh;
    public _navigationType navigationType;
    void Start(){
        if(navigationType.Equals(_navigationType.Next))
            gameObject.GetComponent<Button>().onClick.AddListener(()=> {
                NextPage();
            });
        else
            gameObject.GetComponent<Button>().onClick.AddListener(()=> {
                PreviousPage();
            });
    }

    private void NextPage() {
        Debug.Log(textMesh.pageToDisplay + "/" + textMesh.textInfo.pageCount);
        if(textMesh.pageToDisplay + 1 <= textMesh.textInfo.pageCount)
            ChangePageTo(++textMesh.pageToDisplay);
    }
    private void PreviousPage() {
        Debug.Log(textMesh.pageToDisplay + "/" + textMesh.textInfo.pageCount);
        if(textMesh.pageToDisplay - 1 > 0)
            ChangePageTo(--textMesh.pageToDisplay);
    }
    private void ChangePageTo(int newPage) {
        Debug.Log("Changing to " + newPage);
        textMesh.pageToDisplay = newPage;
    }
}
