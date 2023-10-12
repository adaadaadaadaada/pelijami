using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Fading : MonoBehaviour
{
    public GameObject blackoutimage;
    public GameObject loseScreen;
    public Fading maincanvas;
    public GameObject infobox;
    
    public Rigidbody playerRb;


    void Start()
    {


    }
    public void lightOn()
    {
        StopAllCoroutines();
        StartCoroutine(FadeBlackOutImage(false));
    }
    
    public void LightOff()
    {
        StopAllCoroutines();
        StartCoroutine(FadeBlackOutImage());
    }

    public void Update()
    {
        

    }
    public void EnableGameOverMenu()
    {
        loseScreen.SetActive(true);
    }
    public void EnableInfoBox()
    {
        infobox.SetActive(true);   
    }
    public void DisabledInfoBox()
    {
        infobox.SetActive(false);
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            maincanvas.LightOff();
            DisabledInfoBox();
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            maincanvas.lightOn();
            EnableInfoBox();
        }
    }


    public IEnumerator FadeBlackOutImage(bool fadeToBlack = true, float fadeSpeed = 0.20f)
    {
        Color objectColor = blackoutimage.GetComponent<Image>().color;
        float fadeAmount;

        if (fadeToBlack)
        {
            
            while (blackoutimage.GetComponent<Image>().color.a <= 1)
            {
                fadeAmount = objectColor.a + (fadeSpeed * Time.deltaTime);
                
                objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
                blackoutimage.GetComponent<Image>().color = objectColor;
                Debug.Log("fADE TO BLAKC Alpha " + objectColor.a);
                
                yield return null;

            }

            if (objectColor.a >= 1f)
            {
                EnableGameOverMenu();
            }
        }
        else
        {
            
            while (blackoutimage.GetComponent<Image>().color.a > 0)
            {

                fadeAmount = objectColor.a - (fadeSpeed * Time.deltaTime);

                objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
                blackoutimage.GetComponent<Image>().color = objectColor;
                Debug.Log(" fade back Alpha " + objectColor.a);
                
                yield return null;
            }

        }
    }



}

