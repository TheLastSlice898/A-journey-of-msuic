using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideScripot : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            Debug.Log("oww heck");
            other.gameObject.GetComponent<PlayerController>().Respawn();
        }
    }
}