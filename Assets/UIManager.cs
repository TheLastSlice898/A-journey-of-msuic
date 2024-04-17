using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private PlayerController Player;

    [SerializeField] private TextMeshProUGUI TileScore;
    [SerializeField] private TextMeshProUGUI Lives;
    [SerializeField] private TextMeshProUGUI Song;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TileScore.text = Player.tilesran.ToString();
        Lives.text = Player.lives.ToString();
        //song.text = GameManager.SongManager.clip.name.tostring();


    }
}
