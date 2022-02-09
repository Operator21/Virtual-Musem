using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class QuestionClass
{
	protected string question;
	protected string correctAnswer;
	protected List<string> wrongAnswers;
	public QuestionClass(string dataStructure) {
		setValuesFromString(dataStructure);
	}

	private void setValuesFromString(string dataStructure) {
		if(!dataStructure.Contains(":"))
			return;
		string[] split = dataStructure.Split(":");
		this.question = split[0];

		if(split[1].Length < 1)
			return;
		wrongAnswers = new List<string>();
		string[] extractedAnswers = split[1].Split(",");

		for(int x = 0; x < extractedAnswers.Length; x++){
			if(x == 0)
				this.correctAnswer = extractedAnswers[0].Trim();
			else
				this.wrongAnswers.Add(extractedAnswers[x].Trim());
		}
	}

	public string Question {
		get {
			return question;
		}
	}

	public string CorrectAnswer {
		get {
			return correctAnswer;
		}
	}

	public List<string> Answers {
		get {
			List<string> tmp = new List<string>();
			tmp.AddRange(this.wrongAnswers);
			tmp.Add(this.correctAnswer);
			return tmp.OrderBy(a => Random.Range(int.MinValue, int.MaxValue)).ToList();
		}
		
	}
}
