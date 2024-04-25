using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMusic : MonoBehaviour
{
    private AudioSource AudioSourcemusic;
    [SerializeField] private float Startup;
    // Start is called before the first frame update
    void Start()
    {
        AudioSourcemusic = GetComponent<AudioSource>();
        AudioSourcemusic.Play();

        

    }

    // Update is called once per frame
    void Update()
    {
        
        if (Startup !>= 1f)
        {
            Startup += Time.deltaTime;
        }
        AudioSourcemusic.volume = Mathf.Lerp(0, 1, Startup);

    }
}
