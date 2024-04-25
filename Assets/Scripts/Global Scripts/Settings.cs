using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Settings : MonoBehaviour
{
    private static Settings _instance;
    public static Settings instance { get { return _instance; } }

    //defult

    private void Awake()
    {
        _instance = this;
        
    }
    private void Start()
    {
        
    

    }
    // Start is called before the first frame update

    // Update is called once per frame
    public void SetMasterVolume(float volume)
    {
        AudioListener.volume = volume;
        PlayerPrefs.SetFloat("Volume", volume);
    }
}
