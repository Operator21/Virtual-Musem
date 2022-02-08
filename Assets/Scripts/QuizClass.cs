using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuizClass : MonoBehaviour
{
    public GameObject buttonPrefab;
    public List<string> questions;
    private List<QuestionClass> questionList;
    private TextMeshProUGUI questionText;
    private Transform scrollContent;
    private int posCurrent = 0;
    private int currentQuestion = 0;
    public int buttonHeight = 35;
    private void Start() {
        questionList = new List<QuestionClass>();
        questionText = this.transform.Find("Question").GetComponent<TextMeshProUGUI>();
        scrollContent = this.transform.Find("Scroll View/Viewport/Content");

        foreach(string questionStructure in questions){
            questionList.Add(new QuestionClass(questionStructure));
        }
        DisplayQuestion(questionList[currentQuestion]);
    }

    public void DisplayQuestion(QuestionClass question) {
        questionText.text = question.Question;
        posCurrent = 0;       
        foreach(string answer in question.Answers) {
            GameObject instance = Instantiate(buttonPrefab, new Vector3(0, 0, 0), new Quaternion());
            instance.transform.SetParent(scrollContent, false);
            //Vector3 position = new Vector3(0, this.transform.position.y - posCurrent - posGap, 0);
            instance.transform.GetComponent<RectTransform>().SetInsetAndSizeFromParentEdge(RectTransform.Edge.Top, posCurrent, buttonHeight);
            instance.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(0, buttonHeight);
            posCurrent += buttonHeight;
            instance.transform.Find("Text (TMP)").GetComponent<TextMeshProUGUI>().text = answer;
        }
        scrollContent.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(0, question.Answers.Count * buttonHeight);
    }

    public bool NextQuestion() {
        if(currentQuestion+1 < questionList.Count) {
            DisplayQuestion(questionList[++currentQuestion]);
            return true;
        }
        return false;
    }
}
