using UnityEngine;

public class DiegoArrangementPuzzleController : MonoBehaviour
{
    public GameObject square1;
    public GameObject square2;
    public GameObject square3;
    public GameObject square4;
    public GameObject square5;
    public GameObject square6;
    public GameObject square7;
    public GameObject square8;

    // Update is called once per frame
    void Update()
    {
        CheckSquares();
    }

    void CheckSquares()
    {
        if (square1.transform.position == Vector3.zero) // This will check the 8 box positions once we decide where they go
        {
            PuzzleComplete();
        }
    }

    void PuzzleComplete()
    {

    }
}