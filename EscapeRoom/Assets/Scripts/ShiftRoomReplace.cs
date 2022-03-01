using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShiftRoomReplace : MonoBehaviour
{
    [SerializeField] GameObject[] rooms;
    int i = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftAlt))
        {
            rooms[i].SetActive(false);
            if (i == 3)
                i = -1;
            rooms[i += 1].SetActive(true);
        }
    }
}
