using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Pipes;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;


public class TileGenerator : MonoBehaviour
{
    public int totaltiles;

    public enum States 
    { 
        Started,
        TileGenerating,
        FinishedPath,
        FinishedFinal

    }
    [SerializeField] private States states;
    [SerializeField] private GameObject spawnTile;
    [SerializeField] private GameObject GenerateorTile;
    [SerializeField] private GameObject PlayerCheckTile;
    [SerializeField] private GameObject TurnRight;
    [SerializeField] private GameObject TurnLeft;
    [SerializeField] private GameObject ChoiceTile;
    [SerializeField] private GameObject FinishTile;
    [SerializeField] private GameObject CurrentChoice;
    [SerializeField] private GameObject PreviousTile;
    [SerializeField] private float distanceBetweenTiles;
    [SerializeField] private float distanceBetweenLevels;
    [SerializeField] private int tilesBeforeTurn = 10;
    [SerializeField] private bool CanSpawnTurn = false;
    [SerializeField] private bool CanSpawnChoice = false;
    [SerializeField] private int turns;
    [SerializeField] private Range range = new Range();

    public int TilesbeforeChoice = 100;
    public int CurrentLevel;

    private void Awake()
    {
        PreviousTile = gameObject;
        CanSpawnChoice = false;
        CanSpawnTurn = false;
        StartCoroutine(TileGeneration());
        states = States.Started;
        
        
    }
    // Start is called before the first frame update
    IEnumerator TileGeneration()
    {
        states = States.TileGenerating;
        //yield return new WaitForSeconds(1f);
        while (states == States.TileGenerating)
        {
            
            yield return null;
        Loop:
            float tiledirection = Random.Range(-1f, 1f);
            Debug.Log(tilesBeforeTurn);
            if (tilesBeforeTurn <= 0)
            {
                CanSpawnTurn = true;
            }
            if (TilesbeforeChoice == 0)
            {
                CanSpawnChoice = true;
            }
            if (CanSpawnChoice)
            {

                if (gameObject.GetComponent<GenreScript>().CurrentQuestions.Count > CurrentLevel)
                // if the amount of questions is lower than the current level go to make next level
                {
                    //spawns choice tile
                    SpawnHookTile();

                    CanSpawnChoice = false;

                    GetComponent<TileGenerator>().enabled = false;
                    states = States.FinishedPath;
                    goto end;

                }
            }
            if (tiledirection > 0.5 && CanSpawnTurn && turns > -1) //left
            {
                SpawnLeftTurn();
                
            }
            else // go forward
            {
                SpawnStright();
                
            }

            if (tiledirection < -0.5 && CanSpawnTurn && turns < 1) //right
            {
                SpawnRightTurn();
                
            }
            else // go forward
            {
                SpawnStright();
                
            }

            //Finished Spawned and Finished Coroutine
            if (gameObject.GetComponent<GenreScript>().CurrentQuestions.Count == CurrentLevel)
            {
                var SpawnedFinishTile = Instantiate(FinishTile, PreviousTile.transform.position + distanceBetweenTiles * PreviousTile.transform.forward, transform.rotation);
                //finish and spawn finish tiles
                GetComponent<TileGenerator>().enabled = false;
                Debug.Log("we finished");
                states = States.FinishedFinal;
                goto end;
            }
            goto Loop;


        }

    end:;
    }

    private void SpawnRightTurn()
    {
        var turntile = Instantiate(TurnRight, PreviousTile.transform.position + distanceBetweenTiles * PreviousTile.transform.forward, PreviousTile.transform.rotation);
        PreviousTile = turntile;
        Quaternion newrotation = PreviousTile.transform.rotation * Quaternion.Euler(0, 90, 0);
        var newtile = Instantiate(spawnTile, PreviousTile.transform.position + distanceBetweenTiles * PreviousTile.transform.right, newrotation);
        PreviousTile = newtile;

        tilesBeforeTurn = Mathf.FloorToInt(Random.Range(6, 20));
        CanSpawnTurn = false;
        totaltiles++;
        TilesbeforeChoice--;
        turns++;
    }

    private void SpawnStright()
    {
        var newtile = Instantiate(spawnTile, PreviousTile.transform.position + distanceBetweenTiles * PreviousTile.transform.forward, PreviousTile.transform.rotation);
        PreviousTile = newtile;
        totaltiles++;
        TilesbeforeChoice--;
        tilesBeforeTurn--;
    }

    private void SpawnLeftTurn()
    {
        var turntile = Instantiate(TurnLeft, PreviousTile.transform.position + distanceBetweenTiles * PreviousTile.transform.forward, PreviousTile.transform.rotation);
        PreviousTile = turntile;
        Quaternion newrotation = PreviousTile.transform.rotation * Quaternion.Euler(0, -90, 0);
        var newtile = Instantiate(spawnTile, PreviousTile.transform.position + distanceBetweenTiles * (PreviousTile.transform.right * -1f), newrotation);
        PreviousTile = newtile;

        tilesBeforeTurn = Mathf.FloorToInt(Random.Range(6, 20));
        CanSpawnTurn = false;
        totaltiles++;
        TilesbeforeChoice--;
        turns--;
    }



    private void SpawnHookTile()
    {
        states = States.FinishedPath;

        var SpawnedChoiceTile = Instantiate(ChoiceTile, PreviousTile.transform.position + distanceBetweenTiles * PreviousTile.transform.forward, PreviousTile.transform.rotation);
        PreviousTile = SpawnedChoiceTile;
        SpawnedChoiceTile.GetComponent<ChoiceManager>().CurrentQuestion = gameObject.GetComponent<GenreScript>().CurrentQuestions[CurrentLevel];
        //left and right choice Tiles spawning and set vars
        Quaternion newrotationLeft = PreviousTile.transform.rotation * Quaternion.Euler(0, -90, 0);
        var LeftPlayerCheckTile = Instantiate(PlayerCheckTile, PreviousTile.transform.position + distanceBetweenTiles * (PreviousTile.transform.right * -1f), newrotationLeft);
        LeftPlayerCheckTile.GetComponent<PlayerChoiceCheck>().IsLeft = true;
        LeftPlayerCheckTile.GetComponent<PlayerChoiceCheck>().ChoiceTile = SpawnedChoiceTile;

        Quaternion newrotationRight = PreviousTile.transform.rotation * Quaternion.Euler(0, 90, 0);
        var RightPlayerCheckTile = Instantiate(PlayerCheckTile, PreviousTile.transform.position + distanceBetweenTiles * PreviousTile.transform.right, newrotationRight);

        RightPlayerCheckTile.GetComponent<PlayerChoiceCheck>().IsRight = true;
        RightPlayerCheckTile.GetComponent<PlayerChoiceCheck>().ChoiceTile = SpawnedChoiceTile;
        //spawnbothgenerators upper and lower 
        CurrentLevel++;
        var LowerLevelpos = PreviousTile.transform.position + (distanceBetweenTiles * (PreviousTile.transform.right * -1f) + (distanceBetweenLevels * (PreviousTile.transform.up * -1f)));
        var UpperLevelpos = PreviousTile.transform.position + (distanceBetweenTiles * PreviousTile.transform.right + (distanceBetweenLevels * PreviousTile.transform.up));
        var LeftGeneratorTile = Instantiate(GenerateorTile, LowerLevelpos, newrotationLeft);
        var RightGeneratorTile = Instantiate(GenerateorTile, UpperLevelpos, newrotationRight);

        SpawnedChoiceTile.GetComponent<ChoiceManager>().Left = LeftGeneratorTile;
        LeftGeneratorTile.GetComponent<TileGenerator>().TilesbeforeChoice = totaltiles * 2;
        SpawnedChoiceTile.GetComponent<ChoiceManager>().Right = RightGeneratorTile;
        RightGeneratorTile.GetComponent<TileGenerator>().TilesbeforeChoice = totaltiles * 2;

        
    }
}

