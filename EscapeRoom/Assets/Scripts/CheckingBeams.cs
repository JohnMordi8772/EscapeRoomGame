using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckingBeams : MonoBehaviour
{
    public Beam one, two;
    // Start is called before the first frame update
    void Start()
    {
        one.gameObject.SetActive(false);
        two.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (one.hitReceiver && two.hitReceiver && !PuzzlesFinishedManager.beamPuzzleComplete)
            PuzzlesFinishedManager.Beam();
    }

    public void Activate()
    {
        one.gameObject.SetActive(true);
        two.gameObject.SetActive(true);
    }
}
