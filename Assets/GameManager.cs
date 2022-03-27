using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance { get; private set; }

    public GameObject[] playerSpawners;

    public int player1Lives = 3;

    public PlayerInformation player1Information;
    
    void Awake() {

        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }
        Instance = this;
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
}
