using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCollider : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    public void OnTriggerStay(Collider other)
    {
        Debug.Log("aaaaaaaaaa");
    }
}
