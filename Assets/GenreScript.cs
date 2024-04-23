using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GenreScript : MonoBehaviour
{
    public QuestionGroups CurrentGroup;

    public List<bool> CurrentAnswers;
    public List<string> CurrentQuestions;

   
    private void Awake()
    {
        CurrentGroup = GameManager.instance.CurrentQuestionGroups;

        CurrentAnswers = new List<bool>();
        CurrentQuestions = new List<string>();

        for (int i = 0; i < CurrentGroup.QuestionItems.Length; i++)
        {
            var Questionitem = CurrentGroup.QuestionItems[i];
            CurrentAnswers.Add(Questionitem.yesorno);
            CurrentQuestions.Add(Questionitem.Question);

        }
    }

    public void SetGroup(QuestionGroups group)
    {
        CurrentGroup= group;
    }
    // Update is called once per frame
}
