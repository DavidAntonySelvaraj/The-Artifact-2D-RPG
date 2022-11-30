using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHarvest : MonoBehaviour
{
    [SerializeField] public float harvestTime = 0.4f;
    private PlayerMovement playerMovement;
    private PlayerBackpack playerBackpack;

    private AudioSource audioSource;
    private Collider2D collidedBush;
    private BushFruits hitBushFruits;
    private bool canHarvestFruits;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        playerBackpack = GetComponent<PlayerBackpack>();
        audioSource = GetComponent<AudioSource>();
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E)||(Input.GetKeyDown(KeyCode.Space)))
        {
            TryHarvestFruits();
        }
    }

    void TryHarvestFruits()
    {
        if (!canHarvestFruits)
            return;

        if(collidedBush != null)
        {
            hitBushFruits = collidedBush.GetComponent<BushFruits>();
            if(hitBushFruits.HasFruits())
            {
                audioSource.Play();
                playerMovement.HarvestStopMovement(harvestTime);
                playerBackpack.AddFruits(hitBushFruits.HarvestFruits());
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Bush"))
        {
            //Debug.Log("In");
            canHarvestFruits = true;
            collidedBush = collision;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Bush"))
        {
            canHarvestFruits = false;
            collidedBush = collision;
        }
    }
    


}//class





























