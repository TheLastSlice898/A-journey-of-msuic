using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scoretogglebool : MonoBehaviour
{
    // Start is called before the first frame update
    public void active()
    {
        GameManager.instance._scoremenu = !GameManager.instance._scoremenu;

    }

}
