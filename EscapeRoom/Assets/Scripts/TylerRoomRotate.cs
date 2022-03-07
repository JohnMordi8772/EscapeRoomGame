using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TylerRoomRotate : MonoBehaviour
{
    // Start is called before the first frame update

    public bool isHorizontal;
    public bool isVertical;
    public bool isZertical;
    public GameObject GameController;
    public TylerGameController tgc;

    void Start()
    {
        tgc = GameController.GetComponent<TylerGameController>();
    }


    // Update is called once per frame
    void Update()
    {
        if(transform.position.y == 0)
        {
            isHorizontal = true;
        }
        if (transform.position.x == 0)
        {
            isVertical = true;
        }
        if(transform.position.z == 0)
        {
            isZertical = true;
        }

        if(tgc.canRotate == true)
        {
            if (Input.GetKeyDown(KeyCode.Q) && isHorizontal == true)
            {
                if (transform.position.x > 0)
                {
                    transform.position = new Vector3(0, 0, 5);
                }
                else if (transform.position.x < 0)
                {
                    transform.position = new Vector3(0, 0, -5);
                }
                else if (transform.position.x == 0)
                {
                    if (transform.position.z == 5)
                    {
                        transform.position = new Vector3(-5, 0, 0);
                    }
                    else if (transform.position.z == -5)
                    {
                        transform.position = new Vector3(5, 0, 0);
                    }
                }


            }

            if (Input.GetKeyDown(KeyCode.E) && isHorizontal == true)
            {
                if (transform.position.x < 0)
                {
                    transform.position = new Vector3(0, 0, 5);
                }
                else if (transform.position.x > 0)
                {
                    transform.position = new Vector3(0, 0, -5);
                }
                else if (transform.position.x == 0)
                {
                    if (transform.position.z == 5)
                    {
                        transform.position = new Vector3(5, 0, 0);
                    }
                    else if (transform.position.z == -5)
                    {
                        transform.position = new Vector3(-5, 0, 0);
                    }
                }
            }
            if (Input.GetKeyDown(KeyCode.R) && isVertical == true)
            {
                if (transform.position.y > 0)
                {
                    transform.position = new Vector3(0, 0, 5);
                }
                else if (transform.position.y < 0)
                {
                    transform.position = new Vector3(0, 0, -5);
                }
                else if (transform.position.y == 0)
                {
                    if (transform.position.z == 5)
                    {
                        transform.position = new Vector3(0, -5, 0);
                    }
                    else if (transform.position.z == -5)
                    {
                        transform.position = new Vector3(0, 5, 0);
                    }
                }
            }

            if (Input.GetKeyDown(KeyCode.F) && isVertical == true)
            {
                if (transform.position.y > 0)
                {
                    transform.position = new Vector3(0, 0, -5);
                }
                else if (transform.position.y < 0)
                {
                    transform.position = new Vector3(0, 0, 5);
                }
                else if (transform.position.y == 0)
                {
                    if (transform.position.z == -5)
                    {
                        transform.position = new Vector3(0, -5, 0);
                    }
                    else if (transform.position.z == 5)
                    {
                        transform.position = new Vector3(0, 5, 0);
                    }
                }
            }
            /*if (Input.GetKeyDown(KeyCode.Z) && isZertical == true)
            {
                if (transform.position.y > 0)
                {
                    transform.position = new Vector3(0, 0, 5);
                }
                else if (transform.position.y < 0)
                {
                    transform.position = new Vector3(0, 0, -5);
                }
                else if (transform.position.y == 0)
                {
                    if (transform.position.z == 5)
                    {
                        transform.position = new Vector3(0, -5, 0);
                    }
                    else if (transform.position.z == -5)
                    {
                        transform.position = new Vector3(0, 5, 0);
                    }
                }
            }

            if (Input.GetKeyDown(KeyCode.X) && isZertical == true)
            {
                if (transform.position.y > 0)
                {
                    transform.position = new Vector3(0, 0, -5);
                }
                else if (transform.position.y < 0)
                {
                    transform.position = new Vector3(0, 0, 5);
                }
                else if (transform.position.y == 0)
                {
                    if (transform.position.z == -5)
                    {
                        transform.position = new Vector3(0, -5, 0);
                    }
                    else if (transform.position.z == 5)
                    {
                        transform.position = new Vector3(0, 5, 0);
                    }
                }
            }
            */
        }
    }    
        
}
