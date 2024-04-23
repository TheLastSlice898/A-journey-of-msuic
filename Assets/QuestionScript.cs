using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionScript : MonoBehaviour
{
    // Start is called before the first frame update
    public bool Answer;
    public QuestionObject QuestionObject;

    [SerializeField] private Toggle toggle;
    private Text TextquestionText;

    void Start()
    {
        toggle = GetComponentInChildren<Toggle>();

        TextquestionText =  toggle.GetComponentInChildren<Text>();
    }

    // Update is called once per frame
    void Update()
    {

        TextquestionText.text = QuestionObject.Question;


    }
}
