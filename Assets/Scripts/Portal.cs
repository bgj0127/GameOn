using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class Portal : MonoBehaviour
{
    private AudioSource musicPlay;
    public AudioClip eventMusic;
    // Start is called before the first frame update
    void Start()
    {
        musicPlay = GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D portal)
    {
        if (portal.CompareTag("Player"))
        {
            musicPlay.Play();
            SceneManager.LoadScene("Tutorial");
        }
    }
}
