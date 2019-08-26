using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{
    public float _slimeL;

    public float _slimeR;

    private bool change;
    // Start is called before the first frame update
    void Start()
    {
        change = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (change == true)
        {
            transform.Translate(new Vector2(_slimeL, 0.0f) * Time.deltaTime);
            transform.rotation = Quaternion.Euler(0,0,0);
        }
        else
        {
            transform.Translate(new Vector2(_slimeR,0.0f) * Time.deltaTime);
            transform.rotation = Quaternion.Euler(180,0,180);
        }
    }

    private void OnTriggerEnter2D(Collider2D blk)
    {
        if (blk.CompareTag("L_Block"))
        {
            change = false;
        }
        if (blk.CompareTag("R_Block"))
        {
            change = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Monster"))
        {
            change = !change;
        }
    }
}
