using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{


    public float moveUnits = 1f;
    public float moveSpeed;

    public Transform playerMovePoint;

    public LayerMask whatStopsMovement;

    public Rigidbody2D playerRigidBody;

    // Start is called before the first frame update
    void Start()
    {
        playerMovePoint.parent = null;
    }


    //moves the player
    //takes a key code
    //takes 1 or -1
    public void movePlayer(string k, int x, int y)
    {
        //checks for positive horizontile input
        if (Input.GetKeyDown(k))
        {
            //checks for any objects to the right or left of colider
            if (!Physics2D.OverlapCircle(playerMovePoint.position + new Vector3(x, y, 0f), .2f, whatStopsMovement))
            {

                {
                //moves the player by x units
                playerMovePoint.position += new Vector3(x, y, 0f);
                }
            }
        }
    }



    // Update is called once per frame
    void Update()
    {

        //makes player move towards the move point
        transform.position = Vector3.MoveTowards(transform.position, playerMovePoint.position, moveSpeed * Time.deltaTime);


        //checks if player and move point are very close together
        if (Vector3.Distance(transform.position, playerMovePoint.position) <= .2f)
        {
            movePlayer("right", 1, 0);
            movePlayer("left", -1, 0);
            movePlayer("up", 0, 1);
            movePlayer("down", 0, -1);

        }        
    }
}
