using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;

public class TimeManager : MonoBehaviour
{
     public Text timerText;
    public float timeToWin = 300f;
    private bool gameOver;
    private GameObject artifact;
    private StringBuilder stringBuilder;

    private void Awake()
    {
        artifact = GameObject.FindWithTag("Artifact");
        stringBuilder = new StringBuilder();
    }

    private void Update()
    {
        if (gameOver || !artifact)
            return;


        timeToWin -=Time.deltaTime;

        if(timeToWin <= 0f)
        {
            //WE WIN THE GAME
            timeToWin=0f;
            gameOver=true;
            Destroy(artifact);

            //show win pannel
            GameOverUiController.Instance.GameOver("You Win!");




        }

        //timerText.text = "Time Remaining: " + (int)timeToWin;
        DisplayTimeUsingStringBuilder((int)timeToWin);

    }//update

    void DisplayTimeUsingStringBuilder(int time)
    {
        //reset string builder
        stringBuilder.Length = 0;

        stringBuilder.Append("Time Remaining: ");
        stringBuilder.Append(time);

        timerText.text = stringBuilder.ToString();  
       

    }































}//class




























































