using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TylerGameController : MonoBehaviour
{
    public bool canRotate;
    // Start is called before the first frame update
    void Start()
    {
        canRotate = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        canRotate = true;
    }
    private void OnTriggerExit(Collider other)
    {
        canRotate = false;
    }

}
