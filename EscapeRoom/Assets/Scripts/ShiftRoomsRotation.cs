using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShiftRoomsRotation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            transform.Rotate(0, 0, 45);
            //StartCoroutine(Rotate());
    }

    IEnumerator Rotate()
    {
        float rotated = 0;
        while(rotated < 90)
            transform.Rotate(0, 0, rotated += 90 * Time.deltaTime);
        yield break;
    }
}
