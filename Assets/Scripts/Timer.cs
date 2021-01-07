using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    private int time = 0;
    public Text timer;
    public Text best;
    public AudioClip goalClip;
    string id;

    void Start()
    {
        id = "Best" + SceneManager.GetActiveScene().buildIndex.ToString();

        if (PlayerPrefs.HasKey(id) == true)
        {
            best.text = "Best: " + PlayerPrefs.GetInt(id).ToString();
        }
        else
        {
            best.text = "Brak";
        }

        time = 0;
        InvokeRepeating("IncrimentTime", 1, 1);

        
    }


    public void SetBestTime()
    {
        PlayerPrefs.SetInt(id, time);
        best.text = PlayerPrefs.GetInt(id).ToString();
        PlayerPrefs.Save();
    }


    public void IncrimentTime()
    {
        time += 1;
        timer.text ="Czas: " + time.ToString();
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            var audioSource = GetComponent<AudioSource>();



            if (audioSource != null && goalClip != null)
            {
                audioSource.PlayOneShot(goalClip);
            }

            CancelInvoke();
            if (PlayerPrefs.GetInt(id) == 0)
            {
                SetBestTime();
            }
            if (PlayerPrefs.GetInt(id) > time)
            {
                SetBestTime();
            }


            StartCoroutine(LoadNewLevel(0.5f));
        }
    }

    private IEnumerator LoadNewLevel(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
