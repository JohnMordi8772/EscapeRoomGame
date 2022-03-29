using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzlesFinishedManager : MonoBehaviour
{
    public static bool wirePuzzleComplete, keycodePuzzleComplete, simonSaysComplete, beamPuzzleComplete;
    static GameObject wireImage, keycodeImage, simonImage, beamImage;
    public GameObject wireImageS, keycodeImageS, simonImageS, beamImageS;
    public GameObject door;
    static AudioSource audioSource;
    public AudioClip finished;
    static AudioClip fin;
    // Start is called before the first frame update
    void Start()
    {
        wirePuzzleComplete = false;
        keycodePuzzleComplete = false;
        simonSaysComplete = false;
        beamPuzzleComplete = false;
        wireImage = wireImageS;
        keycodeImage = keycodeImageS;
        simonImage = simonImageS;
        beamImage = beamImageS;
        audioSource = GetComponent<AudioSource>();
        fin = finished;
    }

    // Update is called once per frame
    void Update()
    {
        if (wirePuzzleComplete && keycodePuzzleComplete && simonSaysComplete && beamPuzzleComplete)
            door.SetActive(false);
    }

    public static void Wire()
    {
        wirePuzzleComplete = true;
        wireImage.GetComponent<Image>().color = Color.green;
        PuzzleSolved();
    }

    public static void Keycode()
    {
        keycodePuzzleComplete = true;
        keycodeImage.GetComponent<Image>().color = Color.green;
        PuzzleSolved();
    }

    public static void Simon()
    {
        simonSaysComplete = true;
        simonImage.GetComponent<Image>().color = Color.green;
        PuzzleSolved();
    }

    public static void Beam()
    {
        beamPuzzleComplete = true;
        beamImage.GetComponent<Image>().color = Color.green;
        PuzzleSolved();
    }

    public static void PuzzleSolved()
    {
        audioSource.PlayOneShot(fin);
    }
}
