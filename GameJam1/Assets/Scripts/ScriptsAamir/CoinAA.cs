using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinAA : MonoBehaviour
{

    public ScoreManager ScoreManager;

    private void Start()
    {
        
        ScoreManager = FindObjectOfType<ScoreManager>();

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            
            Destroy(this.gameObject);
            // Updating the score
            ScoreManager.UpdateScore();
        }
    }
}
