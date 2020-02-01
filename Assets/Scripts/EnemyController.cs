using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public float moveSpeed;
    private Transform target;


    public float range;
    private Animator anim;
    private bool enemyMoving;
    private Vector2 eLastMove;
    //private Vector2 direction;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        enemyMoving = false;

        if (Vector3.Distance(target.position, transform.position) <= range )
        {
           
            enemyMoving = true;

            transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
            
            

        }

        anim.SetFloat("EnemyMoveX", transform.position.x);
        anim.SetFloat("EnemyMoveY", transform.position.y);
        anim.SetBool("EnemyMoving", enemyMoving);
        anim.SetFloat("EnemyLastMoveX", eLastMove.x);
        anim.SetFloat("EnemyLastMoveY", eLastMove.y);
    }

    
}
