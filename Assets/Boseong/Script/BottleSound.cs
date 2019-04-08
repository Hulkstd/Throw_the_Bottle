using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleSound : MonoBehaviour
{
    [SerializeField]
    private AudioSource landingSound;

    public bool PlayoneTime = true;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8 && PlayoneTime)
        {
            PlayoneTime = false;

            landingSound.Play();
        }
    }
}
