using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    public GameObject[] playerSpawners;

    public int player1Lives = 3;

    public PlayerInformation player1Information;

    public float handleDuration = 1.0f;
    
    void Awake() {

        if (instance != null && instance != this)
        {
            Destroy(this);
            return;
        }
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        InitialSpawnOfPlayers();

    }

    void InitialSpawnOfPlayers() {
        playerSpawners = GameObject.FindGameObjectsWithTag("PlayerSpawner");

        foreach (GameObject respawn in playerSpawners)
        {
            PlayerSpawner ps = respawn.GetComponent<PlayerSpawner>();
            ps.SpawnPlayer();
        }

    }

    public void SpawnPlayer(int playerNumber) {

        foreach (GameObject respawn in playerSpawners)
        {
            PlayerSpawner ps = respawn.GetComponent<PlayerSpawner>();
            ps.SpawnPlayer();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayerDeathSignal(){

        Debug.Log("Player Death Message Received");
        StartCoroutine(PlayerDeathHandler());

    }

    IEnumerator PlayerDeathHandler(){

        yield return new WaitForSeconds(handleDuration);

        SpawnOrGameOver();
    }

    void SpawnOrGameOver(){

        if(player1Lives <= 0) {

            //Game Over
        }
        else {

            SpawnPlayer(1);
        }
    }

    // Score
    public void ScoreMessage(long value) {

        player1Information.score += value;
        Debug.Log("Score: " + player1Information.score);
    }
}
