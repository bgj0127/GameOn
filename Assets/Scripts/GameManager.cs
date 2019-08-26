using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private int Score;
    private int count = 0;
    public Text countText;
   
    // Start is called before the first frame update
    void Start()
    {
        Score = GameObject.FindGameObjectsWithTag("Point").Length;
        countText.text = count.ToString() + "/" + Score;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Point"))
        {
            count += 1;
            countText.text = count.ToString() + "/" + Score;
        }
    }
}
