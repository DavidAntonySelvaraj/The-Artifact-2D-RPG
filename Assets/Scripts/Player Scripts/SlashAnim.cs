using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashAnim : MonoBehaviour
{

    [SerializeField]private Sprite[] slashSprites;

    [SerializeField]private float timeThreshold;

    [SerializeField] private int damage = 35;

    private SpriteRenderer sr;
    private float timer;
    private int states = 0;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if(Time.time > timer)
        {
            if(states == slashSprites.Length)
            {
                Destroy(gameObject);
                return;
            }
            else
            {
                sr.sprite = slashSprites[states];
                states++;
                timer = Time.time +timeThreshold;
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Wolf"))
        {
            //Debug.Log("Collided with wolf");
            collision.GetComponent<WolfHealth>().TakeDamage(damage);
        }
    }






}//class



































