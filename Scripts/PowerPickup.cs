using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerPickup : MonoBehaviour
{
    public int pointsToAdd;

    public AudioSource redbullSoundEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerController>() == null)
        {
            return;
        }

        powerPoint.AddPoints(pointsToAdd);

        redbullSoundEffect.Play ();

        Destroy(gameObject);
    }
}

