using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ApplePicker : MonoBehaviour
{
    [Header("Inscribe")]
    public GameObject basketPrefab;
    public int numBaskets = 3;
    public float basketBottomY = -14f;
    public float basketSpacingY = 2f;
    // stack of baskets
    public Stack basketStack = new Stack();
    public string difficulty; // difficulty of game
    public string DEFAULT_DIFFICULTY = "hard";
    public bool initialized = false;

    // Start is called before the first frame update
    void Start()
    {
        if (!initialized)
        {
            // set camaera to start
            Vector3 camPos = Camera.main.transform.position;
            camPos.x = -200;
            camPos.y = 0;
            camPos.z = -10;
            Camera.main.transform.position = camPos;
            initialized = true;
        }
        else
        {
            initializeGame(difficulty);
        }
    }

    public void setDifficultyHard()
    {
        initializeGame("hard");
    }

    public void initializeGame( string newDifficulty )
    {
        difficulty = DEFAULT_DIFFICULTY;
        // set to main position
        Vector3 camPos = Camera.main.transform.position;
        camPos.x = 0;
        camPos.y = 0;
        camPos.z = -10;
        Camera.main.transform.position = camPos;
        destroyApples();
        Destroy(GameObject.FindWithTag("OptionButton01"));
        Destroy(GameObject.FindWithTag("OptionButton02"));
        Destroy(GameObject.FindWithTag("OptionButton03"));
        for (int i = 0; i < numBaskets; i++)
        {
            GameObject tBasketGO = Instantiate<GameObject>(basketPrefab);
            Vector3 pos = Vector3.zero;
            pos.y = basketBottomY + (basketSpacingY * i);
            tBasketGO.transform.position = pos;

            // put the basket onto the basket stack
            basketStack.Push(tBasketGO);
        }
        setDifficulty(newDifficulty);
    }

    // set difficulty of the game
    public void setDifficulty( string difficultyString )
    {
        difficulty = difficultyString;

        // destroy barrier on 'easy' mode
        if (difficulty == "easy")
        {
            GameObject barrierObj = GameObject.FindWithTag("Barrier");
            if (barrierObj != null)
            {
                Vector3 pos = barrierObj.transform.position;
                Destroy(barrierObj.gameObject);
            }
        }

        // hard/medium properties are not controlled in this function
    }

    // called when an apple is lost due to boundaries
    public void onAppleLoss()
    {
        // process if basket stack has another element
        if (basketStack.Count > 1)
        {
            // remove and destroy current basket from the stack
            GameObject currentBasket = (GameObject)basketStack.Pop();
            Destroy(currentBasket.gameObject);
        }
        // otherwise, no baskets remaining: restart
        else
        {
            if( basketStack.Count == 1 )
            {
                GameObject currentBasket = (GameObject)basketStack.Pop();
                Destroy(currentBasket.gameObject);
            }
            initializeGame(difficulty);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void destroyApples()
    {
        GameObject[] apples = GameObject.FindGameObjectsWithTag("Apple");
        foreach (GameObject apple in apples)
        {
            Destroy(apple);
        }
    }
}
