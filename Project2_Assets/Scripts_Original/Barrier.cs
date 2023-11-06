using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour
{
    public float leftAndRightEdge = 10f; // distance before turning
    public float speed = 7f;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (this.getDifficulty() == "hard")
        {
            // Basic Movement
            Vector3 pos = transform.position;
            pos.x += speed * Time.deltaTime;
            transform.position = pos;

            if (pos.x < -leftAndRightEdge)
            {
                speed = Mathf.Abs(speed);
            }
            else if (pos.x > leftAndRightEdge)
            {
                speed = -Mathf.Abs(speed);
            }
        }

    }

    string getDifficulty()
    {
        GameObject Cam = GameObject.FindWithTag("MainCamera");
        return Cam.GetComponent<ApplePicker>().GetComponent<ApplePicker>().difficulty;
    }
}

