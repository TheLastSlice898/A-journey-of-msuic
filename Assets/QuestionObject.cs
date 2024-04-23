using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Question", menuName = "Question Object File", order = 1)]
public class QuestionObject : ScriptableObject
{
    public string Question;
    public string CorrectAnswer;
    public string WrongAnswer;
    
    public string Popuptext;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
