using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridPuzzleShifting : MonoBehaviour
{
    [SerializeField] GameObject[] rooms;
    [SerializeField] GameObject puzzlePad;
    GameObject selected;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            puzzlePad.SetActive(!puzzlePad.activeInHierarchy);
            Cursor.visible = puzzlePad.activeInHierarchy;
            if(Cursor.visible)
            {
                Cursor.lockState = CursorLockMode.Confined;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
    }

    public void Select(GameObject button)
    {
        if (selected == null)
        {
            selected = button;
            selected.GetComponent<Image>().color = Color.yellow;
        }
        else if(selected == button)
        {
            selected.GetComponent<Image>().color = Color.white;
            selected = null;
        }
        else if(button.GetComponentInChildren<Text>().text == "" && Vector2.Distance(button.transform.localPosition, selected.transform.localPosition) <= 250) // && Vector2.Distance(button.transform.localPosition, selected.transform.localPosition) )
        {
            string roomNumber = selected.GetComponentInChildren<Text>().text;
            Vector2 temp = rooms[8].transform.position;
            rooms[8].transform.position = rooms[Int32.Parse(roomNumber) - 1].transform.position;
            rooms[Int32.Parse(roomNumber) - 1].transform.position = temp;

            selected.GetComponent<Image>().color = Color.white;
            button.GetComponentInChildren<Text>().text = selected.GetComponentInChildren<Text>().text;
            selected.GetComponentInChildren<Text>().text = "";
            selected = null;
        }
    }
}
