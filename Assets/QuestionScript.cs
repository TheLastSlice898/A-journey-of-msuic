using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestionScript : MonoBehaviour
{
    public delegate void CallPopup(string text);
    public static event CallPopup OnCallPopup;

    // Start is called before the first frame update
    public int ID;
    public bool Answer;
    public QuestionObject QuestionObject;
    [SerializeField] private Button button;
    [SerializeField] private Toggle toggle;
    private string TextquestionText;

    void Start()
    {
        toggle = GetComponentInChildren<Toggle>();
        button = GetComponentInChildren<Button>();
        toggle.isOn = Answer;
        button.GetComponentInChildren<TextMeshProUGUI>().text = QuestionObject.Question;
    }

    // Update is called once per frame
    public void Popup()
    {
        OnCallPopup.Invoke(QuestionObject.Popuptext);
    }
}
