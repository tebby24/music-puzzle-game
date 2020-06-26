using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxTest : MonoBehaviour
{

    public LayerMask whatStopsMovement;
    public LayerMask player;
    public LayerMask canPush;

    public Transform playerTransform;
    public Transform boxTestMovePoint;

    public float moveSpeed;

    Rigidbody2D boxRigidbody;



    // Start is called before the first frame update
    void Start()
    {
        boxTestMovePoint.parent = null;
        boxRigidbody = GetComponent<Rigidbody2D>();
    }


    public bool checkForWall(int x, int y)
    {
        if (Physics2D.OverlapCircle(transform.position + new Vector3(x, y, 0), 0.3f, whatStopsMovement)
            && Physics2D.OverlapBox(transform.position - new Vector3(x * 10, y * 10, 0), new Vector2(Mathf.Abs((x * 20)) + .5f, Mathf.Abs((y * 20)) + .5f), 0f, player))
        {
            return true;
        }
        return false;
    }

    public bool inLine(int x, int y)
    { 
        if(Physics2D.OverlapArea(transform.position, transform.position - new Vector3(x * 20, y * 20, 0), player))
        {
            return true;
        }
        return false;
    }





    public void beingPushed(string k, int x, int y)
    {


            //checks for player behind block
            if (Physics2D.OverlapCircle(transform.position - new Vector3(x, y, 0), 0.1f, player))
            {
                gameObject.layer = 10;
                if (Input.GetKeyDown(k))
                {
                    if (Vector3.Distance(transform.position, boxTestMovePoint.position) <= .05f)
                    {
                        boxTestMovePoint.position += new Vector3(x, y, 0f);
                    }
                }
            }
            //checkf for player not behind block
            else if (!Physics2D.OverlapCircle(transform.position - new Vector3(x, y, 0), 0.1f, player))
            {
                gameObject.layer = 0;
            }

            //checks for active pushing block behind block
            if (Physics2D.OverlapCircle(transform.position - new Vector3(x, y, 0), 0.1f, canPush))
            {
                gameObject.layer = 10;
                if (Input.GetKeyDown(k))
                {
                    if (Vector3.Distance(transform.position, boxTestMovePoint.position) <= .05f)
                    {
                        boxTestMovePoint.position += new Vector3(x, y, 0f);
                    }
                }
            }


    }

    



    // Update is called once per frame
    void Update()
    {

        //makes player move towards the move point
        transform.position = Vector3.MoveTowards(transform.position, boxTestMovePoint.position, moveSpeed * Time.deltaTime);


        if (checkForWall(1, 0) == true)
        {
            gameObject.layer = 8;
        }
        else if (checkForWall(-1, 0) == true)
        {
            gameObject.layer = 8;
        }
        else if (checkForWall(0, 1) == true)
        {
            gameObject.layer = 8;
        }
        else if (checkForWall(0, -1) == true)
        {
            gameObject.layer = 8;
        }

        else if (gameObject.layer != 8)
        {
            if (inLine(1, 0) == true)
            {
                beingPushed("right", 1, 0);
            }

            if (inLine(-1, 0) == true)
            {
                beingPushed("left", -1, 0);
            }

            if (inLine(0, 1) == true)
            {
                beingPushed("up", 0, 1);
            }

            if (inLine(0, -1) == true)
            {
                beingPushed("down", 0, -1);
            }
        }

        else
        {
            gameObject.layer = 0;
        }




        Debug.Log(gameObject.layer);

        //freezes ridgedbody constraints
        if (Physics2D.OverlapBox(transform.position, new Vector2(30, 0.5f), 0, canPush))
        {
            boxRigidbody.constraints = (RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation);

        }

        else if (Physics2D.OverlapBox(transform.position, new Vector2(.5f, 30), 0, canPush))
        {
            boxRigidbody.constraints = (RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation);
        }
    }
}
