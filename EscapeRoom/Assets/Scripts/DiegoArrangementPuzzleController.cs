using UnityEngine;

public class DiegoArrangementPuzzleController : MonoBehaviour
{
    public GameObject square1;
    public GameObject square2;
    public GameObject square3;
    public GameObject square4;
    public GameObject square5;
    public GameObject square6;
    public GameObject square7;
    public GameObject square8;
    public GameObject square9;

    private bool miss1;
    private bool miss2;
    private bool miss3;

    private bool click1 = false;
    private bool click2 = false;
    private bool click3 = false;

    public bool puzzleComplete = false;

<<<<<<< Updated upstream
    // Update is called once per frame
    void Update()
    {
        CheckValues();
=======
    RaycastHit hit;

    public AudioSource hitSound;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
            Physics.Raycast(new Ray(Camera.main.transform.position, Camera.main.transform.forward), out hit, 10f);
        if (hit.collider != null)
        {
            CheckValues(hit);
        }
>>>>>>> Stashed changes
    }

    void CheckValues()
    {
        if (Input.GetMouseButtonDown(0) && Input.mousePosition == square2.transform.position)
        {
            click1 = true;
        }
        else if (Input.GetMouseButtonDown(0) && click1 && Input.mousePosition == square1.transform.position)
        {
            click2 = true;
        }
        else if (Input.GetMouseButtonDown(0) && click2 && Input.mousePosition == square9.transform.position)
        {
            click3 = true;
        }
        else if (Input.GetMouseButtonDown(0) && click3 && Input.mousePosition == square4.transform.position)
        {
            puzzleComplete = true;
        }

        if (Input.GetMouseButtonDown(0) && !miss1)
        {
            miss1 = true;
        }
        else if (Input.GetMouseButtonDown(0) && miss1)
        {
            miss2 = true;
        }
        else if (Input.GetMouseButtonDown(0) && miss2)
        {
            miss3 = true;
        }
        else if (Input.GetMouseButtonDown(0) && miss3)
        {
            miss1 = false;
            miss2 = false;
            miss3 = false;

            click1 = false;
            click2 = false;
            click3 = false;
        }
    }
}