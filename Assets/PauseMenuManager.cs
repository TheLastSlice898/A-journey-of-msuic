using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuManager : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private bool Settingstoggle;

    [SerializeField] private GameObject Settings_gameObject;
    [SerializeField] private GameObject Buttons_gameObject;

    // Update is called once per frame
    void Update()
    {

        if (Settingstoggle)
        {
            Settings_gameObject.SetActive(true);
            Buttons_gameObject.SetActive(false);
        }
        else
        {
            Settings_gameObject.SetActive(false);
            Buttons_gameObject.SetActive(true);
        }
    }
    public void toggle()
    {
        Settingstoggle= !Settingstoggle;
    }
}
