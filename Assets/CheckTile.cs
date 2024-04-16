using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileCheck : MonoBehaviour
{

    [SerializeField] private bool iswalked;
    
    [SerializeField] private bool KillBool;
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player" && !iswalked)
        {
            iswalked = true;
            collision.gameObject.GetComponent<PlayerController>().Increasescre();
            collision.gameObject.GetComponent<PlayerController>().MovementIncrease += 0.005f; 
        }
    }

    // Update is called once per frame
}
