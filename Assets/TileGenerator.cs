using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TileGenerator : MonoBehaviour
{
    public int totaltiles;

    [SerializeField] private GameObject spawnTile;
    [SerializeField] private GameObject GenerateorTile;
    [SerializeField] private GameObject PlayerCheckTile;
    [SerializeField] private GameObject TurnRight;
    [SerializeField] private GameObject TurnLeft;
    [SerializeField] private GameObject ChoiceTile;
    [SerializeField] private GameObject CurrentChoice;
    [SerializeField] private GameObject PreviousTile;
    [SerializeField] private float distanceBetweenTiles;
    [SerializeField] private float distanceBetweenLevels;
    [SerializeField] private int tilesBeforeTurn = 10;
    [SerializeField] private bool CanSpawnTurn = false;
    [SerializeField] private bool CanSpawnChoice = false;
    [SerializeField] private int turns;

    public int TilesbeforeChoice = 100;
    public int CurrentLevel;

    private void Awake()
    {
        CanSpawnChoice= false;
        CanSpawnTurn=false;
    }
    // Start is called before the first frame update
    void Start()
    {
        PreviousTile = gameObject;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.GetComponent<GenreScript>().CurrentQuestions.Count == CurrentLevel)
        {
            //finish and spawn finish tiles
            GetComponent<TileGenerator>().enabled = false;
            Debug.Log("we finished");
            goto End;

        }

        float tiledirection = Random.value;
        //Debug.Log(tiledirection);
        if (tilesBeforeTurn == 0)
        {
            CanSpawnTurn = true;
        }
        if (TilesbeforeChoice== 0)
        {
            CanSpawnChoice= true;
        }

        if (CanSpawnChoice)
        {

            if (gameObject.GetComponent<GenreScript>().CurrentQuestions.Count > CurrentLevel)
            // if the amount of questions is lower than the current level go to make next level
            {

                //spawns choice tile
                var SpawnedChoiceTile = Instantiate(ChoiceTile, PreviousTile.transform.position + distanceBetweenTiles * PreviousTile.transform.forward, PreviousTile.transform.rotation);
            PreviousTile = SpawnedChoiceTile;
            //left and right choice Tiles spawning and set vars
            Quaternion newrotationLeft = PreviousTile.transform.rotation * Quaternion.Euler(0, -90, 0);
            var LeftPlayerCheckTile = Instantiate(PlayerCheckTile, PreviousTile.transform.position + distanceBetweenTiles * (PreviousTile.transform.right * -1f), newrotationLeft);
            LeftPlayerCheckTile.GetComponent<PlayerChoiceCheck>().IsLeft= true;
            LeftPlayerCheckTile.GetComponent<PlayerChoiceCheck>().ChoiceTile= SpawnedChoiceTile;

            Quaternion newrotationRight = PreviousTile.transform.rotation * Quaternion.Euler(0, 90, 0);
            var RightPlayerCheckTile = Instantiate(PlayerCheckTile, PreviousTile.transform.position + distanceBetweenTiles * PreviousTile.transform.right, newrotationRight);
            
            RightPlayerCheckTile.GetComponent<PlayerChoiceCheck>().IsRight = true;
            RightPlayerCheckTile.GetComponent<PlayerChoiceCheck>().ChoiceTile = SpawnedChoiceTile;




                //spawnbothgenerators upper and lower 





                CurrentLevel++;
                var LowerLevelpos = PreviousTile.transform.position + (distanceBetweenTiles * (PreviousTile.transform.right * -1f) + (distanceBetweenLevels * (PreviousTile.transform.up*-1f)));
            var UpperLevelpos = PreviousTile.transform.position + (distanceBetweenTiles * PreviousTile.transform.right + (distanceBetweenLevels * PreviousTile.transform.up));
            var LeftGeneratorTile = Instantiate(GenerateorTile, LowerLevelpos, newrotationLeft);
            var RightGeneratorTile = Instantiate(GenerateorTile, UpperLevelpos, newrotationRight);

            SpawnedChoiceTile.GetComponent<ChoiceManager>().Left = LeftGeneratorTile;
            LeftGeneratorTile.GetComponent<TileGenerator>().TilesbeforeChoice = totaltiles * 2;
            SpawnedChoiceTile.GetComponent<ChoiceManager>().Right = RightGeneratorTile;
            RightGeneratorTile.GetComponent<TileGenerator>().TilesbeforeChoice = totaltiles * 2;



            CanSpawnChoice = false;
            
            GetComponent<TileGenerator>().enabled = false;
            goto End;

            }
         

            //disabletheScript
            
           
            
            
        } 


        if (tiledirection > 0.5 && CanSpawnTurn && turns > -1) //left
        {
            var turntile = Instantiate(TurnLeft,PreviousTile.transform.position + distanceBetweenTiles * PreviousTile.transform.forward,PreviousTile.transform.rotation);
            PreviousTile= turntile;
            Quaternion newrotation = PreviousTile.transform.rotation * Quaternion.Euler(0, -90, 0);
            var newtile = Instantiate(spawnTile, PreviousTile.transform.position + distanceBetweenTiles * (PreviousTile.transform.right * -1f), newrotation);
            PreviousTile = newtile;

            tilesBeforeTurn = Mathf.FloorToInt(Random.Range(4, 20));
            CanSpawnTurn = false;
            totaltiles++;
            TilesbeforeChoice--;
            turns--;
        }
        if (tiledirection < 0.5 && CanSpawnTurn && turns < 1) //right
        {
            var turntile = Instantiate(TurnRight, PreviousTile.transform.position + distanceBetweenTiles * PreviousTile.transform.forward, PreviousTile.transform.rotation);
            PreviousTile = turntile;
            Quaternion newrotation = PreviousTile.transform.rotation * Quaternion.Euler(0, 90, 0);
            var newtile = Instantiate(spawnTile, PreviousTile.transform.position + distanceBetweenTiles * PreviousTile.transform.right, newrotation);
            PreviousTile = newtile;

            tilesBeforeTurn = Mathf.FloorToInt(Random.Range(4, 20));
            CanSpawnTurn = false;
            totaltiles++;
            TilesbeforeChoice--;
            turns++;
        }
        else // goforward
        {
            var newtile = Instantiate(spawnTile, PreviousTile.transform.position + distanceBetweenTiles * PreviousTile.transform.forward, PreviousTile.transform.rotation);
            PreviousTile = newtile;
            totaltiles++;
            TilesbeforeChoice--;
            tilesBeforeTurn--;

        }
    End:;
    
    }
}

