using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteBlockController : MonoBehaviour
{

    public LayerMask player;

    public LevelController levelController;

    [SerializeField] AudioClip[] pianoSounds;

    [SerializeField] int startingNote = 0;
    int newNote;
    public int note;



    // Start is called before the first frame update
    void Start()
    {


        //plays starting chord
        //*notes need to be staggered somehow
        AudioClip winClip1 = pianoSounds[levelController.winNote1];
        GetComponent<AudioSource>().PlayOneShot(winClip1);

        AudioClip winClip2 = pianoSounds[levelController.winNote2];
        GetComponent<AudioSource>().PlayOneShot(winClip2);

        AudioClip winClip3 = pianoSounds[levelController.winNote3];
        GetComponent<AudioSource>().PlayOneShot(winClip3);


        note = startingNote;
    }

    public bool checkForPlayer()
    {
        if(Physics2D.OverlapCircle(transform.position, 1f, player))
        {
            return true;
        }

        return false;
    }


    // Update is called once per frame
    void Update()
    {

        Debug.Log(note);

        //plays noteblock audio
        if (checkForPlayer() == true)
        {
            if (Input.GetKeyUp(KeyCode.X))
            {
                AudioClip clip = pianoSounds[note];
                GetComponent<AudioSource>().PlayOneShot(clip);
            }
        }

        //plays all blocks
        if (Input.GetKeyUp(KeyCode.Space))
        {
            AudioClip clip = pianoSounds[note];
            GetComponent<AudioSource>().PlayOneShot(clip);
        }
    }
}
