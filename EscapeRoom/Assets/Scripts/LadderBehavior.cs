using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderBehavior : MonoBehaviour
{
    bool atLadder;
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && atLadder)
        {
            player.transform.position = new Vector3(0, 10, -2) + gameObject.transform.position;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            atLadder = true;
            player = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
            atLadder = false;
    }
}
