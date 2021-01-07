using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pausemenu : MonoBehaviour
{
    public static bool Pauza = false;
    public GameObject menu;

    void Start()
    {
        menu.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Pauza)
            {
                Wznow();
            }
            else
            {
                Zpauzuj();
            }
        }
        
    }

    public void Wznow ()
    {
        menu.SetActive(false);
        Time.timeScale = 1f;
        Pauza = false;
    }

    void Zpauzuj ()
    {
        menu.SetActive(true);
        Time.timeScale = 0f;
        Pauza = true;
    }

    public void PokazMenu ()
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1f;
    }

    public void Wyjdz()
    {
        Application.Quit();
    }


}
