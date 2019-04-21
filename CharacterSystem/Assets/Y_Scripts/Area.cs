using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Area : MonoBehaviour
{
    private int characterCheckPoint = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Character")
        {
            characterCheckPoint++;
            if (characterCheckPoint >= 4)
            {
                //TODO : 囲えた処理を書く
                Debug.Log("Getだぜ! : " + characterCheckPoint);   
            }
        }
    }
}
