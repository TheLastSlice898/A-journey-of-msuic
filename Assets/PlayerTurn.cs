using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurn : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            var Playerscript = other.gameObject.GetComponent<PlayerController>();
            if (Playerscript.MovementInput > 0.1)
            {
                Playerscript.TurnRight();
            }
            if (Playerscript.MovementInput < -0.1)
            {
                Playerscript.TurnLeft();
            }

            

        }
    }
}
