using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    private GameObject spawn;

    void Start()
    {
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
    }
}
