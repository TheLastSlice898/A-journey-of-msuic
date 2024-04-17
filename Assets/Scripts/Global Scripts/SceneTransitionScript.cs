using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class SceneTransitionScript : MonoBehaviour
{
    // Start is called before the first frame update
    
    void Start()
    {
        
    }

    // Update is called once per frame
    public void LoadSceneSingle(string scenename)
    {
        SceneManager.LoadScene(scenename);
    }
    public void LoadSceneAsync(string scenename)
    {
        SceneManager.LoadSceneAsync(scenename);
    }
}
