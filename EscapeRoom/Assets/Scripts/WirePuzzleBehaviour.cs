using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WirePuzzleBehaviour : MonoBehaviour
{
    public GameObject Green, DarkBlue, LightBlue, Magenta, Black, Yellow, Red, Orange, Empty;
   
    public GameObject winDoor;
    
    public bool openWinDoor;
    // Start is called before the first frame update
    void Start()
    {
       
        openWinDoor = false;
      
    }


    // Update is called once per frame
    void Update()
    {
        if (Green.transform.position == new Vector3(-11, 11, 0) && LightBlue.transform.position == new Vector3(0, 11, 0) && Red.transform.position == new Vector3(11, 11, 0) &&
            DarkBlue.transform.position == new Vector3(-11, 0, 0) && Yellow.transform.position == new Vector3(0, 0, 0) && Magenta.transform.position == new Vector3(11, 0, 0) &&
            Orange.transform.position == new Vector3(-11, -11, 0) && Black.transform.position == new Vector3(0, -11, 0) && Empty.transform.position == new Vector3(11, -11, 0) && !PuzzlesFinishedManager.wirePuzzleComplete)
        {
            PuzzlesFinishedManager.Wire();
        }
        
        if(openWinDoor == true)
        {
            winDoor.SetActive(false);
        }
        else
        {
            winDoor.SetActive(true);
        }
    }
}
