using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathBarrier : MonoBehaviour
{
    private GameObject spawn;

    private void Start()
    {
        // Checks if there is a spawnpoint
        if (GameObject.FindWithTag("Spawnpoint") != null)
        {
            spawn = GameObject.FindWithTag("Spawnpoint");
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Placeholder Player respawner
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.position = spawn.transform.position;
        }
    }
}
