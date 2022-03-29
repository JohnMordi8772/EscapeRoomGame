using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimonButtons : MonoBehaviour
{
    public SimonBehaviour sb;
    public int heldInt;

    public GameObject fb;

    public PlayerBehaviour forSounds;

    static int i;

    private void Start()
    {
        i = 0;
    }

    public void Press()
    {
        if (gameObject.tag == "Simon")
        {
            if (heldInt == sb.simon[i] && sb.active)
            {
                StartCoroutine("Pressed");
                forSounds.Correct();
                i++;
            }
            else
            {
                forSounds.Incorrect();
                sb.Input(heldInt);
                i = 0;
                //sb.StartPuzzle();
            }
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
