using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShiftRoomsRotation : MonoBehaviour
{
    public bool playerPresent = false;
    public float timeToRotate = 0f;
    public float rotationTime = 10f;
    public float rotation = 90f;

    // Update is called once per frame
    void Update()
    {
        if (playerPresent == false)
        {
            timeToRotate += Time.deltaTime;

            if(timeToRotate >= rotationTime)
            {
                transform.Rotate(0, 0, 90);
                timeToRotate = 0;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            playerPresent = true;
        }
        else
        {
            playerPresent = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            playerPresent = false;
        }
        else
        {
            playerPresent = true;
        }
    }

    IEnumerator Rotate()
    {
        float rotated = 0;
        while(rotated < 90)
            transform.Rotate(0, 0, rotated += 90 * Time.deltaTime);
        yield break;
    }
}
