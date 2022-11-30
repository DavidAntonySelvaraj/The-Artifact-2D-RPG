using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float movementSpeed = 10f;
    private Rigidbody2D myBody;
    private Vector2 moveVector;
    private SpriteRenderer sr;

    private float harvestTimer;
    private bool isHarvesting;

    private GameObject artifact;
    // Start is called before the first frame update
    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (Time.time > harvestTimer)
            isHarvesting = false;

        FlipSprite();
    }

    private void FixedUpdate()
    {
        if(isHarvesting)
            myBody.velocity = Vector2.zero;
        else
        {
            moveVector = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        }
        
        if(moveVector.sqrMagnitude>1)
            moveVector = moveVector.normalized;
        myBody.velocity = new Vector2(moveVector.x*movementSpeed,moveVector.y*movementSpeed);
       // Debug.Log(moveVector.sqrMagnitude);


    }

    void FlipSprite()
    {
        if(Input.GetAxisRaw("Horizontal")==1)
        {
            sr.flipX = false;
        }
        else if (Input.GetAxisRaw("Horizontal") == -1)
        {
            sr.flipX = true;
        }
    }
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.CompareTag("Bush"))
    //    {

    //        Debug.Log("The value of the fruit is:   " +
    //            collision.gameObject.GetComponent<BushFruits>().HarvestFruits());
    //    }
    //}
    public void HarvestStopMovement(float time)
    {
        isHarvesting = true;
        harvestTimer = Time.time + time;
    }

    public bool IsHarvesting()
    {
        return isHarvesting;
    }


}//class













