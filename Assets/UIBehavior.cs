using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class UIBehavior : MonoBehaviour
{
    GameManager gameManager;
    
    int livesOnScreen;

    public TextMeshProUGUI player1Score;

    public Image[] lifeImages;

    public TextMeshProUGUI lifeBeyondText;
    public Image imageBeyond;

    public int lifeBeyondCounter = 5;

    public int zeroLength = 9;

    [Header("Score")]
    long scoreValue;
    public TextMeshProUGUI scoreText;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.instance.GetComponent<GameManager>();

        if(gameManager == null) {

            Debug.Log("GameManager is null for UI");
        }
    }

    // Update is called once per frame
    void Update()
    {
        livesOnScreen = gameManager.player1Information.lives;
        scoreValue = gameManager.player1Information.score;

        ManageLifeUI();
        ManageScore();
    }

    void ManageLifeUI()
    {
        if(livesOnScreen <= lifeBeyondCounter) {
            imageBeyond.enabled = false;
            lifeBeyondText.enabled = false;
            
            for (int x = 0 ; x < lifeImages.Length ; x++)
            {
                if(x < livesOnScreen){
                    lifeImages[x].enabled = true;
                }
                else{
                    lifeImages[x].enabled = false;
                }

            }

        }
        else {
            foreach (Image image in lifeImages) {
                image.enabled = false;
            }

            imageBeyond.enabled = true;
            lifeBeyondText.enabled = true;
        }
    }

    void ManageScore() {

    
        int numberOfZeros = zeroLength - scoreValue.ToString().Length;

        string newString = new string('0', numberOfZeros);

        scoreText.text = newString + scoreValue.ToString();

    }
}
