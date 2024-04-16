using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GenreScript : MonoBehaviour
{

    public Genre Chosengenre;
    
    public string[] JazzQuestions;
    public bool[] JazzAnswers;
    public string[] RockQuestions;
    public bool[] RockAnswers;
    public string[] PopQuestions;
    public bool[] PopAnswers;
    public string[] EDMQuestions;
    public bool[] EDMAnswers;

    public int CurrentQuestionInt;
    public List<bool> CurrentAnswers;
    public List<string> CurrentQuestions;


    private void Start()
    {
        switch (Chosengenre) 
        {
            case Genre.Jazz:
                CurrentAnswers = JazzAnswers.ToList();
                CurrentQuestions = JazzQuestions.ToList();
                break;
            case Genre.Rock:
                CurrentAnswers = RockAnswers.ToList();
                foreach (var question in RockQuestions)
                {
                    CurrentQuestions.Add(question);
                }
                break;
            case Genre.Pop:
                CurrentAnswers = PopAnswers.ToList();
                foreach (var question in PopQuestions)
                {
                    CurrentQuestions.Add(question);
                }
                break;
            case Genre.EDM:
                CurrentAnswers = EDMAnswers.ToList();
                foreach (var question in EDMQuestions)
                {
                    CurrentQuestions.Add(question);
                }
                break;
        }

          
    }
    public enum Genre
    {
        Pop,
        Rock,
        Jazz,
        EDM,
    }


    // Update is called once per frame
}
