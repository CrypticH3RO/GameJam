using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // wasn't included in the tutorial video
public class UpdatePlayerInfo : MonoBehaviour
{
    // Set this gameobject from the Scene menu by dragging and dropping
    public GameObject playerScoreObj;
    private GameObject _playerLivesObj; //underscore infront of private variables convention
    public GameObject GameOverText;


    private Text _playerScoreText;
    private Text _playerLivesText;

    public SpawnCharacter SpawnCharacter;

    // Start is called before the first frame update
    void Start()
    {
        GameOverText.SetActive(false);

        _playerScoreText = playerScoreObj.GetComponent<Text>();
        _playerScoreText.text = "Score: 0";

        SpawnCharacter = GameObject.FindObjectOfType<SpawnCharacter>();
        // Could do this in one line the first 2
        _playerLivesObj = GameObject.Find("Lives");
        _playerLivesText = _playerLivesObj.GetComponent<Text>();
        _playerLivesText.text = "Num of Lives: " + SpawnCharacter.NumOfLives;
    }

    public void UpdateScoreText(int score)
    {
        _playerScoreText.text = "Score: " + score;
    }

    public void UpdatePlayerLivesText(int lives)
    {
        _playerLivesText.text = "Num of lives: " + lives;
    }

    public void DisplayGameOver()
    {
        GameOverText.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
