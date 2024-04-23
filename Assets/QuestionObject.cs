using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Question", menuName = "Question Object File", order = 1)]
public class QuestionObject : ScriptableObject
{
    public string Question;
    public bool yesorno;
    public string Popuptext;

    // Start is called before the first frame update
}
