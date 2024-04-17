using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private int lives;
    public GameObject RespawnPoint;
    [SerializeField] private Animator animator;
    [SerializeField] private float MovementInput;
    [SerializeField] private float MovementSpeed;
    public float MovementIncrease = 1f;



    public int tilesran;

    public List<bool> PlayerAnswers;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        MovementInput = Input.GetAxis("Horizontal");
        transform.position += transform.forward * (MovementSpeed * MovementIncrease) * Time.deltaTime;
    }

    public void TurnLeft()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Quaternion currentrotation = transform.rotation;
            transform.rotation = (currentrotation * Quaternion.Euler(0f, -90f, 0f));
        }
    }
    public void TurnRight()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Quaternion currentrotation = transform.rotation;
            transform.rotation = (currentrotation * Quaternion.Euler(0f, 90f, 0f));
        }
    }


    public float ReturnMovementIncrease()
    {
        return MovementIncrease;
    }

    public void Increasescre()
    {
        tilesran++;
    }
    public void Teleport(Transform Location)
    {

        gameObject.transform.position = Location.position;

    }
    public void Respawn()
    {
        if (lives == 0)
        {
            Die();
        }
        else
        {
            lives--;
            transform.position = RespawnPoint.transform.position;
        }

    }
    public void Die()
    {
        string thisscene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(thisscene);
    }

    public void AddAnswer(bool answer)
    {
        PlayerAnswers.Add(answer);


    }

}
