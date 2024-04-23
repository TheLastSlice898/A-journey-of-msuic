using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PopupScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator animator;
    private void OnEnable()
    {
        QuestionScript.OnCallPopup += PopupSend;
    }
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void PopupSend(string Text)
    {
        animator.SetTrigger("Popup");
        GetComponentInChildren<TextMeshProUGUI>().text = Text;
    }

}
