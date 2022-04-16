using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuizClass : MonoBehaviour
{
    public GameObject buttonPrefab;
    [TextArea(1,5)]
    public List<string> questions;
    private List<QuestionClass> questionList;
    private TextMeshProUGUI questionText;
    private TextMeshProUGUI scoreText;
    private Transform answerContent;
    private int posCurrent = 0;
    private int currentQuestion = 0;
    private int score = 0;
    public int buttonHeight = 35;
    public bool showInPrecentage = false;
    void Start() {
        questionList = new List<QuestionClass>();
        scoreText = this.transform.Find("Score").GetComponent<TextMeshProUGUI>();
        questionText = this.transform.Find("Question").GetComponent<TextMeshProUGUI>();
        answerContent = this.transform.Find("Content");

        foreach(string questionStructure in questions){
            questionList.Add(new QuestionClass(questionStructure));
        }
        DisplayQuestion(questionList[currentQuestion]);
    }

    public void DisplayQuestion(QuestionClass question) {
        questionText.text = question.Question;       
        posCurrent = 0;       
        ClearContent();
        //answerContent.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(220, question.Answers.Count * buttonHeight);
        foreach(string answer in question.Answers) {
            GameObject instance = CreateButton(answer);
            instance.GetComponent<Button>().onClick.AddListener(() => {
                if(instance.transform.Find("Text (TMP)").GetComponent<TextMeshProUGUI>().text == questionList[currentQuestion].CorrectAnswer)
                    score+=1;
                if(!NextQuestion()){
                    questionText.text = "Kvíz dokončen";
                    posCurrent = 0;
                    ClearContent();
                    GameObject button = CreateButton("Zkusit znovu");
                    //answerContent.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(220, buttonHeight);
                    button.GetComponent<Button>().onClick.AddListener(() => { 
                        ResetQuiz();
                        //answerContent.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(220, question.Answers.Count * buttonHeight);
                    });
                }
            });
        }        
    }

    public bool NextQuestion() {
        if(currentQuestion+1 < questionList.Count) {
            DisplayQuestion(questionList[++currentQuestion]);
            return true;
        }
        return false;
    }

    private GameObject CreateButton(string content){
        GameObject instance = Instantiate(buttonPrefab, new Vector3(0, 0, 0), new Quaternion());
        instance.transform.SetParent(answerContent, false);
        //instance.transform.GetComponent<RectTransform>().SetInsetAndSizeFromParentEdge(RectTransform.Edge.Top, posCurrent, buttonHeight);
        instance.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(220, buttonHeight);
        posCurrent += buttonHeight;
        instance.transform.Find("Text (TMP)").GetComponent<TextMeshProUGUI>().text = content;
        return instance;
    }

    private void ClearContent(){
        foreach(Transform child in answerContent.transform)
            Destroy(child.gameObject);
        scoreText.text = currentScore;
    }

    private void ResetQuiz(){
        currentQuestion = 0;
        score = 0;
        ClearContent();
        DisplayQuestion(questionList[currentQuestion]);
    }

    private string currentScore {
        get {
            if(showInPrecentage){
                if(score == 0)
                    return "Úspěšnost: 0%";
                return "Úspěšnost: " + (score/(questionList.Count/100.0)).ToString("0.00") + "%";
            }
            return score + "/" + questionList.Count;
        }
    }
}
