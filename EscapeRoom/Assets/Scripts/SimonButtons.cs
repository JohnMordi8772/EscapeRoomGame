using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimonButtons : MonoBehaviour
{
    public SimonBehaviour sb;
    public int heldInt;

    public GameObject fb;

    public void Press()
    {
        if (heldInt >= 0 && sb.active)
        {
            StartCoroutine("Pressed");
        }
        else
        {
            sb.StartPuzzle();
        }
    }

    public IEnumerator Pressed()
    {
        sb.Input(heldInt);
        fb.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        fb.SetActive(false);
    }
}
