using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    
    private TMPro.TextMeshProUGUI scoreText;

    private GameObject spawn;

    public static int score ;

    private int allGems;

    void Start()
    {
        // Sets score back to 0
        score = 0;

        // Checks if there is a spawnpoint
        if (GameObject.FindWithTag("Spawnpoint") != null)
        {
            spawn = GameObject.FindWithTag("Spawnpoint");
        }

        // Checks if there in a Player instance and if not spawns one
        if (GameObject.FindWithTag("Player") == null && player != null)
        {
            Instantiate(player, spawn.transform);
        }

        // Checks for the score count text
        if (GameObject.FindWithTag("ScoreText") != null)
        {
            scoreText = GameObject.FindWithTag("ScoreText").GetComponent<TMPro.TextMeshProUGUI>();
            Debug.Log("Found text.");
        }

        // Checks how many Gems there are for the score text
        if (GameObject.FindWithTag("GemsHolder") != null)
        {
            allGems = GameObject.FindWithTag("GemsHolder").transform.childCount;
        }
    }

    private void Update()
    {
        // Keeps updating the score text
        if (scoreText != null)
        {
            scoreText.text = score + " / " + allGems + " Gems";
        }

    }

}
