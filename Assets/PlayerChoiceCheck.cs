using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerChoiceCheck : MonoBehaviour
{
    public GameObject ChoiceTile;
    public bool IsLeft;
    public bool IsRight;


    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            if (IsLeft)
            {
                collision.gameObject.GetComponent<PlayerController>().Teleport(ChoiceTile.GetComponent<ChoiceManager>().Left.transform);
                collision.gameObject.GetComponent<PlayerController>().RespawnPoint = ChoiceTile.GetComponent<ChoiceManager>().Left;
                ChoiceTile.GetComponent<ChoiceManager>().DestroyRight();
            }
            if (IsRight)
            {
                collision.gameObject.GetComponent<PlayerController>().Teleport(ChoiceTile.GetComponent<ChoiceManager>().Right.transform);
                collision.gameObject.GetComponent<PlayerController>().RespawnPoint = ChoiceTile.GetComponent<ChoiceManager>().Right;
                ChoiceTile.GetComponent<ChoiceManager>().DestoryLeft();
            }

        }
    }
}
