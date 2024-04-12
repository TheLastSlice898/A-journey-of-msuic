using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private Animator animator;
    [SerializeField] private float MovementInput;
    [SerializeField] private float MovementSpeed;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        MovementInput = Input.GetAxis("Vertical");

        rb.velocity = new Vector3 (0f,0f , (MovementInput * -1) * MovementSpeed);




    }
}
