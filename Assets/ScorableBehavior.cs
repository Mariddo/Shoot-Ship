using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorableBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    GameManager gameManager;

    public ScoreValue scoreValue;

    void Start()
    {
        gameManager = GameManager.instance.GetComponent<GameManager>();
    }

    public void AwardScore(){

        gameManager.ScoreMessage(scoreValue.value);
    }
    
}
