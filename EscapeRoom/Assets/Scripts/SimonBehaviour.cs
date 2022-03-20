using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimonBehaviour : MonoBehaviour
{
    public List<int> simon;
    public List<int> player;

    public GameObject[] simon_;

    public bool active = false;
    public int playerPos = 0;

    public IEnumerator SimonSays()
    {
        player = new List<int>();
        simon = new List<int>();

        for (int i = 0; i < 4; i++)
        {
            yield return new WaitForSeconds(0.5f);
            simon.Add(Random.Range(0, 4));
            simon_[simon[i]].SetActive(true);
            yield return new WaitForSeconds(1f);
            simon_[simon[i]].SetActive(false);
        }
    }

    public void StartPuzzle()
    {
        active = true;
        StartCoroutine("SimonSays");
    }

    public void Input(int i)
    {
        if (active == true)
        {
            if (i == simon[playerPos])
            {
                player.Add(i);
                playerPos += 1;
            }
            else
            {
                player = new List<int>();
                simon = new List<int>();
                active = false;
            }

            if (playerPos == simon.Count - 1)
            {
                print("Done");
            }
        }
    }
}
