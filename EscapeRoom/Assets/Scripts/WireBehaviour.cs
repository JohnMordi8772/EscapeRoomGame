using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireBehaviour : MonoBehaviour
{
    public GameObject GridManager;
    public GridPuzzleShifting gps;
    public bool wiresInOrder;
    void Start()
    {
        wiresInOrder = false;
        gps = GridManager.GetComponent<GridPuzzleShifting>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
