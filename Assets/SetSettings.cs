using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetSettings : MonoBehaviour
{
    [SerializeField] private Slider slider;
    private void Start()
    {
        slider = GetComponent<Slider>();
        slider.value = PlayerPrefs.GetFloat("Volume");
    }
    // Start is called before the first frame update
    public void CallFullscreen(int screenenum)
    {
    }
    public void CallVolume(float volume)
    {
        Settings.instance.SetMasterVolume(volume);
    }
}
