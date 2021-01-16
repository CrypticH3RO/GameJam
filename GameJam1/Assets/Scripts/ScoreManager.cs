using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int playerScore = 0;

    public UpdatePlayerInfo UpdatePlayerInfo;
    // Start is called before the first frame update
    void Start()
    {
        UpdatePlayerInfo = GameObject.FindObjectOfType<UpdatePlayerInfo>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScore()
    {
        playerScore += 1;
        UpdatePlayerInfo.UpdateScoreText(playerScore);
    }
}
