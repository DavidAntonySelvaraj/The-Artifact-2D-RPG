using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfAnimations : MonoBehaviour
{
    [SerializeField] private Sprite[] wolfAnimSprite;
    [SerializeField] float animThersholdTime = .15f;
    private WolfAi wolfAi;
    private SpriteRenderer sr;

    private int state=0;
    private float animTimer;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        wolfAi = GetComponent<WolfAi>();
    }

    private void Update()
    {
        if (wolfAi.isMoving)
        {
            if (Time.time > animTimer)
            {
                sr.sprite = wolfAnimSprite[state % wolfAnimSprite.Length];
                state++;

                if (state == wolfAnimSprite.Length)
                    state = 0;

                animTimer = Time.time + animThersholdTime;
            }
        }


        else
        {
            sr.sprite = wolfAnimSprite[0];
        }

        sr.flipX = wolfAi.left;
    }




}//class






































































