using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beam : MonoBehaviour
{
    [SerializeField] GameObject receiver;
    RaycastHit hit;
    Ray ray;
    [SerializeField] LineRenderer lr;
    [SerializeField] GameObject beamProjector;


    // Start is called before the first frame update
    void Start()
    {
        lr.SetPosition(0, beamProjector.transform.position);
        transform.position = beamProjector.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(Physics.Raycast(ray = new Ray(transform.position, transform.forward), out hit, 30) && hit.collider.tag != "Player")
        {
            //if (hit.transform.gameObject.tag == "Receiver")
            //{
            //    GetComponent<MeshRenderer>().material.color = Color.green;
            //    hit.transform.gameObject.GetComponent<MeshRenderer>().material.color = Color.green;
            //}
            lr.SetPosition(1, hit.point);
        }
    }

    public void SetBeamStart()
    {
        lr.SetPosition(0, beamProjector.transform.position);
        transform.position = beamProjector.transform.position;
    }
}
