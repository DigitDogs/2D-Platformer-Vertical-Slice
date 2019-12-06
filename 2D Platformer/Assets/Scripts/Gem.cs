using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Gem : MonoBehaviour
{
    private AudioSource gemSoundEffect;

    private bool pickedUp = false;

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

        // Looks if the player collided and a small safety feature for multiple hits
        if (collision.gameObject.CompareTag("Player") && pickedUp == false)
        {
            pickedUp = true;
            PickedUp();
        }
    }

    /// <summary>
    /// Plays sound effect, adds 1 point to the score in the GameManager and destroys this gameobject.
    /// </summary>
    private void PickedUp()
    {

        // adds 1 to score in the GameManager
        GameManager.score++;

        gemSoundEffect.Play();
        Destroy(this.gameObject);
    }
}
