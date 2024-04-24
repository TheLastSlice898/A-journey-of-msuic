using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public delegate void AddScore(float score);
    public static event AddScore OnAddScore;

    private Rigidbody rb;
    public int lives;
    [SerializeField] CameraTrack cam;
    public GameObject RespawnPoint;
    [SerializeField] private Animator animator;
    public float MovementInput;
    [SerializeField] private float MovementSpeed;
    public float MovementIncrease = 1f;
  

    public int tilesran;

    public List<bool> PlayerAnswers;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        cam.speed = MovementIncrease/10;
        MovementInput = Input.GetAxis("Horizontal");
        animator.SetFloat("Input", MovementInput);
        transform.position += transform.forward * (MovementSpeed * MovementIncrease) * Time.deltaTime;
    }

    public void TurnLeft()
    {
        Quaternion currentrotation = transform.rotation;
        transform.rotation = (currentrotation * Quaternion.Euler(0f, -90f, 0f));
    }
    public void TurnRight()
    {
        Quaternion currentrotation = transform.rotation;
        transform.rotation = (currentrotation * Quaternion.Euler(0f, 90f, 0f));
    }


    public float ReturnMovementIncrease()
    {
        return MovementIncrease;
    }

    public void Increasescre()
    {
        tilesran++;
        OnAddScore.Invoke(100f);
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
            gameObject.transform.position = RespawnPoint.transform.position;
            gameObject.transform.rotation = RespawnPoint.transform.rotation;
        }

    }
    public void Die()
    {
        
        SceneManager.LoadScene("StartMenu");
    }

    public void AddAnswer(bool answer)
    {
        PlayerAnswers.Add(answer);


    }
}
