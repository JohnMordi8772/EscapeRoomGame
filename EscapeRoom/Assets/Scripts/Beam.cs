using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beam : MonoBehaviour
{
    [SerializeField] GameObject receiver;
    RaycastHit hit;
    Ray ray;


    // Start is called before the first frame update
    void Start()
    {
        ray = new Ray(transform.position, transform.forward);
    }

    // Update is called once per frame
    void Update()
    {
        if(Physics.Raycast(ray, out hit, 20))
        {
            if (hit.transform.gameObject.tag == "Receiver")
            {
                GetComponent<MeshRenderer>().material.color = Color.green;
                hit.transform.gameObject.GetComponent<MeshRenderer>().material.color = Color.green;
            }
        }
    }
}
