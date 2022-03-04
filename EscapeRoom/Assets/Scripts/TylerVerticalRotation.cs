using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TylerVerticalRotation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            transform.Rotate(90, 0, 0);

        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            transform.Rotate(-90, 0, 0);

        }
    }
}
