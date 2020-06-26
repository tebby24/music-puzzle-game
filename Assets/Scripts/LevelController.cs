using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{

    //connects LevelController scipt to noteblocks
    public NoteBlockController noteBlock1;
    public NoteBlockController noteBlock2;
    public NoteBlockController noteBlock3;

    public Canvas winButton;

    private bool winningSolution;

    [SerializeField] public int winNote1;
    [SerializeField] public int winNote2;
    [SerializeField] public int winNote3;


    // Start is called before the first frame update
    void Start()
    {
        winButton.enabled = false;
    }


    //checks if any noteBlocks are equal to a specific note
    private bool checkForNote(int note)
    {
        if (
            noteBlock1.note == note
            ||
            noteBlock2.note == note
            ||
            noteBlock3.note == note
            )
        {
            return true;
        }
        return false;
    }


    // Update is called once per frame
    void Update()
    {

        //checks for all winning notes
        //*should probably be a loop
        if(checkForNote(winNote1) == true && checkForNote(winNote2) == true && checkForNote(winNote3) == true)
        {
            winningSolution = true;
        }
        else
        {
            winningSolution = false;
        }


        if(winningSolution == true)
        {
            if(Input.GetKeyUp(KeyCode.Space))
            {
                winButton.enabled = true;
                Debug.Log("you win");
            }
        }

    }
}
