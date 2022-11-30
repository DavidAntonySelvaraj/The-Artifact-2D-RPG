using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSlash : MonoBehaviour
{
    [SerializeField] private GameObject slashPrefab;
    [SerializeField] private float attackCoolDown = .3f;
    private float attackTimer;
    private AudioSource audioSource;
    private Camera Maincamera;
    private Vector3 spawnPosition;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        //Maincamera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();     //or
        Maincamera = Camera.main;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0)&&Time.time>attackTimer)
        {
            Slash();
            audioSource.Play();
            attackTimer = Time.time + attackCoolDown;
        }
    }

    void Slash()
    {
        spawnPosition = Maincamera.ScreenToWorldPoint(Input.mousePosition);
        spawnPosition.z = 0;
        Instantiate(slashPrefab,spawnPosition,Quaternion.identity);
    }



















}//class
























