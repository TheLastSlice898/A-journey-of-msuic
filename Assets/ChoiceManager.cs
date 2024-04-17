using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChoiceManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI Text;
    public string CurrentQuestion;
    public bool CorrectAnswer;
    public GameObject Left;
    public GameObject Right;

   
    // Update is called once per frame
    void Update()
    {
        Text.text = CurrentQuestion;
    }

    public void DestoryLeft()
    {   
        Destroy(Left);
    }
    public void DestroyRight()
    {
        Destroy(Right);
    }



}
