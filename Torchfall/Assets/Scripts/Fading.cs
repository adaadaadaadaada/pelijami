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
    public Fading maincanvas;
    
    public Rigidbody playerRb;


    void Start()
    {


    }
    public void lightOn()
    {
        StopAllCoroutines();
        StartCoroutine(FadeBlackOutImage(false));
    }
    public void StopPlayer()
    {
        playerRb.isKinematic = true;
    }
    public void LightOff()
    {
        StopAllCoroutines();
        StartCoroutine(FadeBlackOutImage());
    }

    public void Update()
    {
        

    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            maincanvas.LightOff();
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            maincanvas.lightOn();

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
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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

