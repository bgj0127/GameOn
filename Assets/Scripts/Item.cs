using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    private AudioSource musicPlay;
    public AudioClip eventMusic;
    public float FadeSpeed;
    public SpriteRenderer _fade;
    private Color color;

    void Start()
    {
        musicPlay = GetComponent<AudioSource>();
        color = _fade.color;
    }

    // Update is called once per frame
    void Update()
    {
        color = _fade.color;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            musicPlay.Play();
            StartCoroutine("FadeOut");
            gameObject.GetComponent<CapsuleCollider2D>().enabled = false; // or false
            Destroy(this.gameObject,0.5f);
        }
    }

    IEnumerator FadeOut()
    {
        while (true)
        {
            if (color.a > 0)
            {
                color.a -= 0.7f;
                _fade.color = color;
            }

            yield return new WaitForSeconds(FadeSpeed);
        }
    }
}
