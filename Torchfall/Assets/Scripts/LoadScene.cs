using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public GameObject gameoverMenu;

    public GameObject Player;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            EnableGameOverMenu();
            Destroy(Player);
        }
    }
    
    public void ResetScene()
    {
        print("Testi");
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void EnableGameOverMenu()
    {
        gameoverMenu.SetActive(true);
    }
}
