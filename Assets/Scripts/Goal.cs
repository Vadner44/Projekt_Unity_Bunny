﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    public AudioClip goalClip;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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


            StartCoroutine(LoadNewLevel(0.5f));
        }
    }

    private IEnumerator LoadNewLevel(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
