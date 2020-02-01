using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed;
    public bool grabbed;
    public float distance=2f;
    public Transform holdpoint;
    public float throwForce;
    public LayerMask notgrabbed;

    private Transform target;
    private Animator anim;
    private bool playerMoving;
    private bool playerMovingHU;
    [SerializeField]
    private bool handsUp;
    private Vector2 lastMove;

    RaycastHit2D hit;
    float dir = -1.0f;

    void Start()
    {
        anim = GetComponent<Animator>();
        
    }

    void Update()
    {
        playerMoving = false;
        playerMovingHU = false;


        Vector2 axis = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
       if (Mathf.Abs(axis.x) > 0.5f )
        {
            dir = axis.x / Mathf.Abs(axis.x);
            transform.Translate(new Vector3(axis.x * moveSpeed * Time.deltaTime, 0f, 0f));
            playerMoving = true;
            lastMove = new Vector2(axis.x, 0f);
            if (handsUp == true)
            {
                playerMovingHU = true;
            }
        }
        if (Mathf.Abs(axis.y) > 0.5f)
        {
            dir = axis.y / Mathf.Abs(axis.y);
            transform.Translate(new Vector3(0f, axis.y * moveSpeed * Time.deltaTime, 0f));
            playerMoving = true;
            lastMove = new Vector2(0f, axis.y);
            if (handsUp == true)
            {
                playerMovingHU = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log("Hands " + handsUp + " | Grab" + grabbed);
            if (handsUp == false && !grabbed)
            {
                Physics2D.queriesStartInColliders = false;

                
                bool forward = Mathf.Abs(lastMove.x) > Mathf.Abs(lastMove.y);

                if (forward)
                {
                    hit = Physics2D.Raycast(transform.position, Vector2.right*dir * transform.localScale.x, distance);
                }  
                else
                {
                    hit = Physics2D.Raycast(transform.position, Vector2.up*dir * transform.localScale.y, distance);
                }
                Debug.Log(dir);
                if (hit.collider != null && hit.collider.tag=="Grab")
                {
                    grabbed = true;
                    handsUp = true;
                }
                
                //grab
            }
            else if (!Physics2D.OverlapPoint(holdpoint.position, notgrabbed))
            {
                grabbed = false;
                if (hit.collider.gameObject.GetComponent<Rigidbody2D>() != null)
                {
                    hit.collider.gameObject.GetComponent<Rigidbody2D>().velocity = lastMove * throwForce;
                }

                handsUp = false;
                //not grab
                
            }
        }

        if (grabbed)
            hit.collider.gameObject.transform.position = holdpoint.position;


        anim.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
        anim.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));
        anim.SetFloat("MoveXHU", Input.GetAxisRaw("Horizontal"));
        anim.SetFloat("MoveYHU", Input.GetAxisRaw("Vertical"));
        anim.SetBool("HandsUp", handsUp);
        anim.SetBool("PlayerMoving", playerMoving);
        anim.SetBool("PlayerMovingHU", playerMovingHU);
        anim.SetFloat("LastMoveX", lastMove.x);
        anim.SetFloat("LastMoveY", lastMove.y);
        //anim.SetFloat("LastMoveXH", lastMove.x);
        //anim.SetFloat("LastMoveYH", lastMove.y);

    }

   

}    
 