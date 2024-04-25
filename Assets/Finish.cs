using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    public delegate void FinishDelegate(bool[] bools);
    public static event FinishDelegate OnFinishDelegae;

    [SerializeField] private UnityEvent MyEvent;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            GameManager.instance.AnswersStatic = other.gameObject.GetComponent<PlayerController>().PlayerAnswers.ToArray();
            SceneManager.LoadSceneAsync("ScoreScene",LoadSceneMode.Additive);
            other.gameObject.GetComponent<PlayerController>().enabled = false;
            MyEvent.Invoke();
        }
    }

}
