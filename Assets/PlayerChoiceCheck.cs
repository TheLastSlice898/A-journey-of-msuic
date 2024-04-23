using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerChoiceCheck : MonoBehaviour
{
    public GameObject ChoiceTile;
    public bool IsLeft;
    public bool IsRight;
    [SerializeField] private Color Right;
    [SerializeField] private Color Wrong;

    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            if (IsLeft) //left is always false
            {
                
                collision.gameObject.GetComponent<PlayerController>().Teleport(ChoiceTile.GetComponent<ChoiceManager>().Left.transform);
                collision.gameObject.GetComponent<PlayerController>().RespawnPoint = ChoiceTile.GetComponent<ChoiceManager>().Left;
                
                collision.gameObject.GetComponent<PlayerController>().AddAnswer(false);
            }
            if (IsRight) // right is always true
            {
                
                collision.gameObject.GetComponent<PlayerController>().Teleport(ChoiceTile.GetComponent<ChoiceManager>().Right.transform);
                collision.gameObject.GetComponent<PlayerController>().RespawnPoint = ChoiceTile.GetComponent<ChoiceManager>().Right;

                collision.gameObject.GetComponent<PlayerController>().AddAnswer(true);

            }
           



        }
    }
    private void Start()
    {
        if (IsLeft)
        {
            gameObject.GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", Wrong);
        }
        if (IsRight)
        {
            gameObject.GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", Right);
        }
    }
}
