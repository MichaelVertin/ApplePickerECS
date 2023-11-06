using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Apple : MonoBehaviour
{
    // apple cannot exist below bottomY
    public static float bottomY = -20f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if( transform.position.y <= bottomY )
        {
            GameObject Cam = GameObject.FindWithTag("MainCamera");

            /*
            Debug.Log(GameObject.Find("ApplePicker"));
            Debug.Log("assigned cam successful\n");
            Debug.Log(Cam);
            Debug.Log("--------------------------");
            Debug.Log("Camera object:\n");
            Debug.Log(Cam.GetComponent<ApplePicker>());
            Debug.Log(Cam.GetComponent<ApplePicker>().GetComponent<ApplePicker>());
            */

            // call onAppleLoss from ApplePicker
            Cam.GetComponent<ApplePicker>().GetComponent<ApplePicker>().onAppleLoss();

            Destroy(this.gameObject);
        }
    }




}
