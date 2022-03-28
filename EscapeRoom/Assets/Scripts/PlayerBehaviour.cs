using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public Camera cam;
    public Rigidbody rb;
    public CapsuleCollider coll;
    
    public bool grounded = false;
    public PhysicMaterial normal;
    public PhysicMaterial slip;
    public ContactPoint[] contacts;
    public List<Vector3> groundNormals;
    public List<Vector3> hits;
    public Vector3 groundNormal;
    public Vector3 point;
    public Vector3 pointDir;
    public Vector3 curveCenterBottom;

    public Vector3 moveDir;
    public float moveForce;
    public float walkSpeed = 10f;
    public float sprintSpeed = 20f;
    public float crouchSpeed = 5f;
    public float speedCap = 10f;

    public Vector3 finalMove;
    /*
    public float jumpForce = 200f;
    public bool jumped = false;
    */

    public bool itemHeld = false;
    public Vector3 handPos;
    public FixedJoint fj;
    public GameObject item;

    public bool crouched = false;

    public KeyCode sprint = KeyCode.LeftControl;
    public KeyCode crouch = KeyCode.LeftShift;
    public float sensitivity = 200f;

    public bool canLook = true;

    Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        moveDir = (transform.right * Input.GetAxisRaw("Horizontal") + transform.forward * Input.GetAxisRaw("Vertical")).normalized;
        if (canLook)
        {
            CameraMovement();
        }
        Crouch();

        if (Input.GetKeyDown(KeyCode.E))
        {
            GrabItem();
        }
        else if (Input.GetKey(KeyCode.R))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }

        if (transform.position.y < -20)
            transform.position = startPosition;
    }

    void FixedUpdate()
    {
        if (grounded == true)
        {
            coll.material = normal;

            if (moveDir != Vector3.zero)
            {
                Movement();
            }
        }
        else
        {
            coll.material = slip;
        }
    }

    /// <summary>
    /// Calls GroundCheck, inserting its contact points
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision)
    {
        contacts = new ContactPoint[collision.contactCount];
        collision.GetContacts(contacts);
        GroundCheck(contacts);
    }

    /// <summary>
    /// Calls GroundCheck, inserting its contact points, only called if ungrounded while still colliding with something
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionStay(Collision collision)
    {
        if (grounded == false)
        {
            contacts = new ContactPoint[collision.contactCount];
            collision.GetContacts(contacts);
            GroundCheck(contacts);
        }
    }

    /// <summary>
    /// Controls the camera
    /// </summary>
    void CameraMovement()
    {
        xRotation = Mathf.Clamp(xRotation - Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime, -90f, 90f);
        cam.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime);
    }

    /// <summary>
    /// Alters camera height and collider height to simulate crouching
    /// </summary>
    void Crouch()
    {
        if (Input.GetKeyDown(crouch))
        {
            coll.height /= 1.5f;
            coll.center = new Vector3(0, -0.25f, 0);
            cam.transform.localPosition = new Vector3(0, 0, 0);
            crouched = true;
        }

        if (Input.GetKeyUp(crouch))
        {
            coll.height *= 1.5f;
            coll.center = new Vector3(0, 0, 0);
            cam.transform.localPosition = new Vector3(0, 0.5369999f, 0);
            crouched = false;
        }
    }

    /// <summary>
    /// Contains the script for walking based on where the player is touching the ground (needs revising for corners)
    /// </summary>
    void Movement()
    {
        if (crouched == true)
        {
            speedCap = crouchSpeed;
        }
        else if (Input.GetKey(sprint))
        {
            speedCap = sprintSpeed;
        }
        else
        {
            speedCap = walkSpeed;
        }

        /*curveCenterBottom = coll.bounds.center - Vector3.up * (coll.bounds.extents.y - coll.radius);

        RaycastHit hit;
        if (Physics.SphereCast(curveCenterBottom, coll.radius, Vector3.ProjectOnPlane(moveDir, groundNormal), out hit))
        {
            
        }*/
        if (rb.velocity.magnitude < speedCap)
        {
            finalMove = Vector3.ProjectOnPlane(moveDir, groundNormal);

            rb.AddForce(finalMove * moveForce, ForceMode.Impulse);
        }
    }

    /// <summary>
    /// Used to jump
    /// </summary>
    /*void Jump()
    {
        if (Input.GetKeyDown(jump))
        {
            if (grounded == true)
            {
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                jumped = true;
            }
        }
    }*/

    float xRotation;

    void GrabItem()
    {
        if (itemHeld == false)
        {
            RaycastHit hit;

            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, 5))
            {
                GameObject hit_ = hit.collider.gameObject;

                if (hit_.tag == "Item")
                {
                    item = hit_;
                    item.transform.parent = gameObject.transform;
                    item.transform.localPosition = handPos;
                    itemHeld = true;
                }
                else if(hit_.tag == "Simon")
                {
                    hit_.GetComponent<SimonButtons>().Press();
                }
                else if(hit_.tag == "NumberCube")
                {
                    GameObject NumberCube = hit_;
                    GameObject ChangedKey;
                    switch (NumberCube.name)
                    {
                        case "Cube 4":
                            ChangedKey = GameObject.Find("Key 4");
                            ChangedKey.GetComponent<MeshRenderer>().material = NumberCube.GetComponent<MeshRenderer>().material;
                            Destroy(NumberCube);
                            break;
                        case "Cube 1":
                            ChangedKey = GameObject.Find("Key 2");
                            ChangedKey.GetComponent<MeshRenderer>().material = NumberCube.GetComponent<MeshRenderer>().material;
                            Destroy(NumberCube);
                            break;
                        case "Cube 2":
                            ChangedKey = GameObject.Find("Key 1");
                            ChangedKey.GetComponent<MeshRenderer>().material = NumberCube.GetComponent<MeshRenderer>().material;
                            Destroy(NumberCube);
                            break;
                        case "Cube 3":
                            ChangedKey = GameObject.Find("Key 9");
                            ChangedKey.GetComponent<MeshRenderer>().material = NumberCube.GetComponent<MeshRenderer>().material;
                            Destroy(NumberCube);
                            break;
                    }
                }    
            }
        }
        else
        {
            RaycastHit hit;

            if (Physics.Raycast(item.transform.position, Vector3.down, out hit))
            {
                item.transform.position = hit.point + new Vector3(0, item.GetComponent<Collider>().bounds.extents.y, 0);
                item.transform.parent = hit.collider.gameObject.transform;
                item = null;
                itemHeld = false;
            }
        }
    }

    /// <summary>
    /// Script used to find a grounding or wall hop-off point
    /// </summary>
    /// <param name="contacts_">
    /// Contacts gathered when OnCollisionEnter is called
    /// </param>
    void GroundCheck(ContactPoint[] contacts_)
    {
        groundNormals = new List<Vector3>();
        hits = new List<Vector3>();
        point = Vector3.zero;
        groundNormal = Vector3.zero;
        //jumped = true;

        curveCenterBottom = coll.bounds.center - Vector3.up * (coll.bounds.extents.y - coll.radius);
        Vector3 curveCenterTop = coll.bounds.center + Vector3.up * (coll.bounds.extents.y - coll.radius);

        foreach (ContactPoint c in contacts_)
        {
            Vector3 dir = curveCenterBottom - c.point;
            Vector3 dir2 = c.point - curveCenterTop;

            if (dir.y > 0f && Mathf.Abs(Vector3.Angle(c.normal, Vector3.up)) <= 40)
            {
                groundNormals.Add(c.normal);
                hits.Add(c.point);

                grounded = true;
                //jumped = false;
            }
        }

        //Ground normal calculation
        if (grounded == true)
        {
            if (groundNormals.Count == 1)
            {
                groundNormal = groundNormals[0];
                point = hits[0];
            }
            else
            {
                for (int i = 0; i < groundNormals.Count; i++)
                {
                    groundNormal += groundNormals[i];
                    point += hits[i];

                    groundNormal /= 2;
                    point /= 2;
                }
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.contactCount == 0)
        {
            grounded = false;
        }
        else
        {
            contacts = new ContactPoint[collision.contactCount];
            collision.GetContacts(contacts);
            GroundCheck(contacts);
        }
    }
}
