using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    [SerializeField] private Sprite[] animSprites;
    public float timeTheshold = .1f;
    private float timer;
    private int state = 0;
    private SpriteRenderer sr;
    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if(Time.time>timer)
        {

            sr.sprite = animSprites[state % animSprites.Length];
            //Debug.Log(state+"%"+animSprites.Length+"="+sr.sprite);
            state++;
            timer = Time.time + timeTheshold;
        }
    }

}//class



























