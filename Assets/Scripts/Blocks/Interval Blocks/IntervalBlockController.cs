using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntervalBlockController : MonoBehaviour
{

    public NoteBlockController noteBlock1;
    public NoteBlockController noteBlock2;
    public NoteBlockController noteBlock3;

    [SerializeField] public int interval;


    private void Start()
    {
        
    }


    public void OnTriggerEnter2D(Collider2D block)
    {
        if(block.name == "Note Block 1")
        {
            noteBlock1.note += interval;
        }
        else if (block.name == "Note Block 2")
        {
            noteBlock2.note += interval;
        }
        else if (block.name == "Note Block 3")
        {
            noteBlock3.note += interval;
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "Note Block 1")
        {
            noteBlock1.note -= interval;
        }
        else if (other.name == "Note Block 2")
        {
            noteBlock2.note -= interval;
        }
        else if (other.name == "Note Block 3")
        {
            noteBlock3.note -= interval;
        }
    }
}
