using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCharacterAA : MonoBehaviour
{
    private GameObject _playerChar;
    private Transform _playerTransform;
    private Rigidbody _rigidbody;
    private Vector3 _charSpawnLocation = new Vector3(4.144f, 1.86f, -1.587f);


    private const float RespawnHeight = -50f;

    public int PlayerLivesLeft;
    public const int NumOfLives = 3;
    public bool GameEnded = false;
    public UpdatePlayerInfoAA UpdatePlayerInfo;

    // Start is called before the first frame update
    void Start()
    {
        _playerChar = GameObject.Instantiate(Resources.Load("Character"),
            _charSpawnLocation, Quaternion.identity) as GameObject;
        _playerTransform = _playerChar.transform;

        _rigidbody = _playerChar.GetComponent<Rigidbody>();

        PlayerLivesLeft = NumOfLives;

        UpdatePlayerInfo = GameObject.FindObjectOfType<UpdatePlayerInfoAA>();
    }

    // Update is called once per frame
    void Update()
    {
        if(_playerTransform.position.y <= RespawnHeight)
        {
            if (PlayerLivesLeft > 0)
            {
                // moving them back at that location
                _playerTransform.position = _charSpawnLocation;
                // Resetting the velocity/momentum
                _rigidbody.velocity = new Vector3(0, 0, 0);
                PlayerLivesLeft -= 1;
                UpdatePlayerInfo.UpdatePlayerLivesText(PlayerLivesLeft);
            }
            else
            {
                EndGame();
                UpdatePlayerInfo.DisplayGameOver();
            }
        }
    }

    private void EndGame()
    {
        GameEnded = true;
        Time.timeScale = 0;
        Debug.Log("Game has ended");
    }
}
