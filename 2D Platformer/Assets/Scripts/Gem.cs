using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Gem : MonoBehaviour
{
    private AudioSource gemSoundEffect;

    private void Start()
    {
        // Searches and attaches the coin sound effect
        if (GameObject.FindWithTag("PickupSoundEffect") != null)
        {
            gemSoundEffect = GameObject.FindWithTag("PickupSoundEffect").GetComponent<AudioSource>();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("TRIGERED");

        // Looks if collision is the player and plays sound effect
        if (collision.gameObject.CompareTag("Player"))
        {
            gemSoundEffect.Play();
            Destroy(this.gameObject);
        }
    }
}
