using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfAi : MonoBehaviour
{
    [SerializeField] private bool isEater;
    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private int attackDamage = 5;
    [SerializeField] private float attackTimeThreshold =1f;
    [SerializeField] private float eatTimeThreshold = 2f;
    [SerializeField] private LayerMask bushMask;
    [HideInInspector] public bool isMoving,left;
    private ArtifactScript artifact;
    private BushFruits bushFruitsTarget;
    private float attackTimer;
    private float eatTimer;
    private bool killingBush;
    private bool isAttacking;


    private void Start()
    {
        if(isEater)
        {
            //SearchForTarget();
            killingBush = false;
        }
        else
        {
            isAttacking = false;
        }

        artifact = GameObject.FindWithTag("Artifact").GetComponent<ArtifactScript>();
    }

    private void Update()
    {

        if(!artifact)
            return;
        if(isEater)
        {
            if(bushFruitsTarget&&bushFruitsTarget.enabled&&bushFruitsTarget.HasFruits()&&!killingBush)
            {
                //if not close to the bush continue walking towards it,else stop and eat the bush
                if(Vector2.Distance(transform.position,bushFruitsTarget.transform.position)>.5f)
                {
                    float step = moveSpeed * Time.deltaTime;
                    transform.position = Vector2.MoveTowards(transform.position, bushFruitsTarget.transform.position, step);
                    isMoving = true;
                }
                else
                {
                    isMoving = false;
                    bushFruitsTarget.HarvestFruits();
                    eatTimer = Time.time + eatTimeThreshold;
                    killingBush = true;
                }
            }
            else if(killingBush)
            {
                if(Time.time>eatTimer)
                {
                    bushFruitsTarget.EatBushFruits();
                    killingBush = false;
                    SearchForTarget();
                }
            }
            else
            {
                SearchForTarget();
            }

            if(bushFruitsTarget)
            {
                if (bushFruitsTarget.transform.position.x < transform.position.x)
                    left = true;
                else
                    left = false;

            }

            if (!bushFruitsTarget)
                SearchForTarget();
            
            
        }
        else
        {
            //wolf that destroys artifact
            if(Vector2.Distance(transform.position,artifact.transform.position)>1.5)
            {
                float step = moveSpeed* Time.deltaTime;
                transform.position = Vector2.MoveTowards(transform.position, artifact.transform.position, step);
                isMoving = true;
            }
            else if(!isAttacking)
            {
                isAttacking = true;
                attackTimer = Time.time + attackTimeThreshold;

                isMoving = false;
            }

            if (isAttacking)
            {

                if(Time.time>attackTimer)
                {
                    Attack();
                    attackTimer = Time.time + attackTimeThreshold;
                }

            }
            if(artifact.transform.position.x < transform.position.x)
                left=true;
            else
                left=false;
        }
    }
    void SearchForTarget()
    {
        bushFruitsTarget = null;
        Collider2D[] hits;

        for(int i=1;i<50;i++)
        {
            hits = Physics2D.OverlapCircleAll(transform.position,Mathf.Exp(i),bushMask);
            foreach(Collider2D hit in hits)
            {
                if (hit && (hit.GetComponent<BushFruits>().HasFruits() && hit.GetComponent<BushFruits>().enabled))
                {
                    bushFruitsTarget = hit.GetComponent<BushFruits>();
                    break;
                }
            }
            if (bushFruitsTarget)
                break;
        }
    }

    void Attack()
    {
        artifact.TakeDamage(attackDamage);
    }







}//class



























