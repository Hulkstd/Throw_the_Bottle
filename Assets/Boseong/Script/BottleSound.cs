﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleSound : MonoBehaviour
{
    [SerializeField]
    private AudioSource landingSound;

    public bool PlayoneTime = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8 && PlayoneTime)
        {
            PlayoneTime = false;

            landingSound.Play();
        }
    }
}
