using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BushVisual : MonoBehaviour
{
    [SerializeField] private Sprite[] bushSprites, fruitSprites, drySprites;
    [SerializeField] private SpriteRenderer[] fruitsRenderer;

    public enum BushVarient { Green,Cyan,Yellow}
    private BushVarient bushVarient;

    public float hideTimePerFruit = .2f;
    private SpriteRenderer sr;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        bushVarient = (BushVarient)Random.Range(0,bushSprites.Length);
        sr.sprite = bushSprites[(int)bushVarient];
        int a=Random.Range(0, 2);
       // Debug.Log(a);
        if(a==1)
            sr.flipX = true;

        for(int i = 0; i<fruitsRenderer.Length; i++)
        {
            fruitsRenderer[i].sprite = fruitSprites[(int)bushVarient];
            fruitsRenderer[i].enabled = false;  
        }

    }

    public BushVarient GetBushVarient()
    {
        return bushVarient;
    }

    public void SetToDry()
    {
        sr.sprite = drySprites[(int)bushVarient];
    }

    IEnumerator _HideFruits(float time,int index)
    {
        yield return new WaitForSeconds(time);
        fruitsRenderer[index].enabled = false;
    }

    public void HideFruits()
    {
        float waitTimeForFruit = hideTimePerFruit;

        for (int i = 0;i< fruitsRenderer.Length;i++)
        {
            StartCoroutine(_HideFruits(waitTimeForFruit, i));
            waitTimeForFruit += hideTimePerFruit;
        }
    }

    public void ShowFruits()
    {
        
            for (int i = 0; i < fruitsRenderer.Length; i++)
                fruitsRenderer[i].enabled = true;
        
    }


}//class





























