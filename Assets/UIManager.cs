using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{


    private void OnEnable() => PlayerController.OnAddScore += AddScoreToUI;
    private void OnDisable() => PlayerController.OnAddScore -= AddScoreToUI;

    [SerializeField] private PlayerController Player;

    [SerializeField] private TextMeshProUGUI CurrentScoreText;
    [SerializeField] private float CurrentScore;
    [SerializeField] private float initalScore;
    [SerializeField] private float DesiredScore;
    [SerializeField] private TextMeshProUGUI Lives;
    [SerializeField] private TextMeshProUGUI Song;

    [SerializeField] private float AnimationTime;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (CurrentScore != DesiredScore)
        {
            if (initalScore < DesiredScore)
            {
                CurrentScore += (AnimationTime * Time.deltaTime) * (DesiredScore - initalScore);
                if (CurrentScore >= DesiredScore)
                    CurrentScore = DesiredScore;

            }

            else
            {
                CurrentScore -= (AnimationTime * Time.deltaTime) * (initalScore - DesiredScore);
                if (CurrentScore <= DesiredScore)
                {
                    CurrentScore = DesiredScore;
                }
            }
            
        }



        CurrentScore = Mathf.Ceil(CurrentScore);
        CurrentScoreText.text = CurrentScore.ToString();
        Lives.text = Player.lives.ToString();
        //song.text = GameManager.SongManager.clip.name.tostring();


    }

    public void AddScoreToUI(float score)
    {
        Debug.Log($"i tried for {score}");
        initalScore = CurrentScore;
        DesiredScore += score;

    }


}
