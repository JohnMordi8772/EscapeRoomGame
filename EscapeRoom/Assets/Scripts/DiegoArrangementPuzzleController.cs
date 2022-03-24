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

    public bool click1 = false;
    public bool click2 = false;
    public bool click3 = false;

    public bool puzzleComplete = false;

    RaycastHit hit;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
            Physics.Raycast(new Ray(Camera.main.transform.position, Camera.main.transform.forward), out hit, 10f);
        if (hit.collider != null) 
            CheckValues(hit);
    }

    void CheckValues(RaycastHit hit)
    {
        if (hit.collider.gameObject.transform.position == square2.transform.position)//Input.GetMouseButtonDown(0) && Input.mousePosition == square2.transform.position)
        {
            click1 = true;
            print("click1");
        }

        else if (click1 == true  && hit.collider.gameObject.transform.position == square1.transform.position)
        {
            click2 = true;
            print("click2");
        }
        else if (click1 == true && click2 != true && hit.collider.gameObject.transform.position != square1.transform.position)
        {
            click1 = false;
            click2 = false;
            click3 = false;
        }
        else if (click2 == true  && hit.collider.gameObject.transform.position == square4.transform.position)
        {
            click3 = true;
            print("click3");
        }
        else if (click2 == true && click3 == false && hit.collider.gameObject.transform.position != square4.transform.position)
        {
            click1 = false;
            click2 = false;
            click3 = false;
        }
        else if (click3 == true && hit.collider.gameObject.transform.position == square9.transform.position)
        {
            PuzzlesFinishedManager.Keycode();
        }
        else if (click3 == true && hit.collider.gameObject.transform.position != square9.transform.position)
        {
            click1 = false;
            click2 = false;
            click3 = false;
        }


       /* if (miss1 == true)
        {

            click1 = false;
            click2 = false;
            click3 = false;
            miss1 = false;
        }*/
    }
}