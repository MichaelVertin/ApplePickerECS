using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class Basket : MonoBehaviour
{
    public Text scoreGT;

    // Start is called before the first frame update
    void Start()
    {
        GameObject scoreGO = GameObject.Find("ScoreCounter");
        // Get the Text Component of that GameObject
        scoreGT = scoreGO.GetComponent<Text>();
        scoreGT.text = "0";
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject collideObj = collision.gameObject;
        if (collideObj.CompareTag("Apple"))
        {
            // Parse the text of the scoreGT into an int
            int score = int.Parse(scoreGT.text);
            score += 100;
            // Convert the score back to a string and display it
            scoreGT.text = score.ToString();

            // assign high score if current is larger
            if( score > HighScore.score )
            {
                HighScore.score = score;
            }
            Destroy(collideObj);
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos2D = Input.mousePosition;
        mousePos2D.z = -Camera.main.transform.position.z;
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);
        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        this.transform.position = pos;
    }
}
