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
    public bool handsUp;
    private Vector2 lastMove;

    RaycastHit2D hit;
    public Item objectRef;

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
                if (hit.collider != null )
                {
                    if (hit.collider.CompareTag("Grab") || hit.collider.CompareTag("Head")|| hit.collider.CompareTag("Body")|| hit.collider.CompareTag("Legs"))
                    {
                        objectRef = hit.collider.gameObject.GetComponent<Item>();
                        grabbed = true;
                        handsUp = true;
                        objectRef.IsGrab=true;
                        //objectRef.GetComponent<Collider2D>().isTrigger = true;
                    }
                    else if (hit.collider.CompareTag("Shop") && GameManager.GetInstance().Money >= 100)
                    {
                        objectRef=hit.collider.GetComponent<ShopBehaviour>().Purchase().GetComponent<Item>();
                        grabbed = true;
                        handsUp = true;
                        objectRef.IsGrab = true;
                       // objectRef.GetComponent<Collider2D>().isTrigger = true;
                    }
                    else if (hit.collider.CompareTag("Table") && hit.collider.transform.childCount>0)
                    {
                        objectRef = hit.collider.transform.GetChild(0).GetComponent<Item>();
                        hit.collider.transform.GetChild(0).SetParent(null);
                        grabbed = true;
                        handsUp = true;
                        objectRef.IsGrab = true;
                    }

                }
                
                //grab
            }
            else if (!Physics2D.OverlapPoint(holdpoint.position, notgrabbed))
            {
                grabbed = false;
                if (objectRef != null)
                {
                    objectRef.gameObject.GetComponent<Rigidbody2D>().velocity = lastMove * throwForce;
                    
                    //objectRef.GetComponent<Collider2D>().isTrigger = false;
                    objectRef.IsGrab = false;
                    objectRef = null;
                }

                handsUp = false;
                //not grab
                
            }
        }

        if (objectRef != null && grabbed)
            objectRef.transform.position = holdpoint.position;
        else
        {
            handsUp = false;
        }


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
 