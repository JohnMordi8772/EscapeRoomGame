using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beam : MonoBehaviour
{
    RaycastHit hit;
    Ray ray;
    [SerializeField] LineRenderer lr;
    [SerializeField] GameObject beamProjector;
    [SerializeField] Gradient red, green;
    public bool hitReceiver;


    // Start is called before the first frame update
    void Start()
    {
        lr.SetPosition(0, beamProjector.transform.position);
        transform.position = beamProjector.transform.position;
        lr.startColor = Color.red;
        lr.endColor = Color.red;
        hitReceiver = false;
    }

    // Update is called once per frame
    void Update()
    {
        SetBeamStart();
        if (Physics.Raycast(ray = new Ray(transform.position, transform.forward), out hit, 30) && hit.collider.tag != "Player")
        {
            //if (hit.transform.gameObject.tag == "Receiver")
            //{
            //    GetComponent<MeshRenderer>().material.color = Color.green;
            //    hit.transform.gameObject.GetComponent<MeshRenderer>().material.color = Color.green;
            //}
            lr.SetPosition(1, hit.point);
            //Debug.Log(hit.collider.gameObject.tag);
            if(hit.collider.gameObject.tag == "Receiver")
            {
                hitReceiver = true;
                lr.startColor = Color.green;
                lr.endColor = Color.green;
            }
            else
            {
                hitReceiver = false;
                lr.startColor = Color.red;
                lr.endColor = Color.red;
            }
        }
    }

    public void SetBeamStart()
    {
        lr.SetPosition(0, beamProjector.transform.position);
        transform.position = beamProjector.transform.position;
    }
}
