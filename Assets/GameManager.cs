using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager instance { get { return _instance; } }
    public bool _paused;
    [SerializeField] private GameObject _pauseMenu;
    public bool _scoremenu;
    public bool[] AnswersStatic;
    [SerializeField] private AudioSource _audioSource;
    public QuestionGroups CurrentQuestionGroups;
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {

            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    private void Update()
    {
        if (SceneManager.GetActiveScene().name != "TempleGame" && !_scoremenu)
        {
            Cursor.visible = true;
        }

       if (_paused)
        {
            Time.timeScale = 0.0f;
            _pauseMenu.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Time.timeScale = 1.0f;
            _pauseMenu.SetActive(false);
        }
    }
    public void ChangeSong(AudioClip song)
    {
        _audioSource.clip = song;  
        _audioSource.Play();
    }
}
