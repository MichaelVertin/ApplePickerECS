using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    [Header("Inscribed")]
    // Start is called before the first frame update
    public GameObject applePrefab; // apple prefab

    public float speed = 10f; // speed of the tree

    public float leftAndRightEdge = 15f; // distance before turning

    public int framesToUpdateDir = 150;

    public float changeDirChance = 1f/3f;

    public float appleDropDelay = 1f;

    public int updateCount = 0;


    void Start()
    {
        
        Invoke("DropApple", 2f);

    }

    // Update is called once per frame
    void Update()
    {
        updateCount += 1;

        // Basic Movement
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        if( pos.x < -leftAndRightEdge )
        {
            speed = Mathf.Abs(speed);
        }
        else if( pos.x > leftAndRightEdge )
        {
            speed = -Mathf.Abs(speed);
        }
        else if( updateCount % framesToUpdateDir == 0 )
        {
            if (Random.value < changeDirChance)
            {
                speed *= -1; // change direction
            }
        }
    }

    void DropApple()
    {
        GameObject apple = Instantiate<GameObject>(applePrefab);
        apple.transform.position = transform.position;
        Invoke("DropApple", 2);
    }

}
