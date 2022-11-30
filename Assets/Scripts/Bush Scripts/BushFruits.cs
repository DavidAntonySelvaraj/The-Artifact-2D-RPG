using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BushFruits : MonoBehaviour
{
    [SerializeField] private int[] amountPerType;
    [SerializeField] private float[] respawnTime;
    private BushVisual bushVisual;
    private bool hasFruits;
    private float timer;

    private void Start()
    {
        bushVisual = GetComponent<BushVisual>();

        if(Random.Range(0,2)==0)
        {
            hasFruits = false;
            timer = Time.time + respawnTime[(int)bushVisual.GetBushVarient()];
        }
        else
        {
            hasFruits = true;
            bushVisual.ShowFruits();
        }

    }


    private void Update()
    {
        if(Time.time>timer)
        {
            hasFruits = true;
            bushVisual.ShowFruits();
        }
    }

    public int HarvestFruits()
    {
        if(hasFruits)
        {
            hasFruits = false;
            bushVisual.HideFruits();
            timer = Time.time + respawnTime[(int)bushVisual.GetBushVarient()];
            return amountPerType[(int)bushVisual.GetBushVarient()];

        }
        else
            return 0;
    }    

    public bool HasFruits()
    {
        return hasFruits;
    }

    //when enemy eats the fruits
    public void EatBushFruits()
    {
        enabled = false;
        bushVisual.SetToDry();
    }

    



}//class













