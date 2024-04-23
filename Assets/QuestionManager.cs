using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class QuestionManager : MonoBehaviour
{
    public GameObject[] questionOBJs;
    //public bool[] Answers;
    public QuestionGroups CurrentQuestions;
    [SerializeField] private Transform parent;
    [SerializeField] private GameObject QuestionPrefab;
    // Start is called before the first frame update
    void Start()
    {
        CurrentQuestions = GameManager.instance.CurrentQuestionGroups;
        
        List<GameObject> questionOBJ = new List<GameObject>();
        foreach (QuestionObject question in CurrentQuestions.QuestionItems)
        {

            var newquestion = Instantiate(QuestionPrefab, parent);
            var questionscript = newquestion.GetComponent<QuestionScript>();
            questionscript.Answer = question.yesorno;
            questionscript.QuestionObject = question;
            questionOBJ.Add(newquestion);
        }
        questionOBJs = questionOBJ.ToArray();

        for (int i = 0; i < questionOBJs.Length; i++)
        {
           
            questionOBJs[i].GetComponent<QuestionScript>().ID = i;
        }
    }

    // Update is called once per frame
}
