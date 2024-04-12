using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrack : MonoBehaviour
{
    
    public Transform Lookat;
    
    public float traildistance;
    public float height;
    public float speed;
    // Update is called once per frame
    void FixedUpdate()
    {

        Vector3 followpos = Lookat.position - Lookat.forward * traildistance;
        followpos.y += height;
        transform.position += (followpos - transform.position) * speed;

        transform.LookAt(Lookat.position);

    }
}
