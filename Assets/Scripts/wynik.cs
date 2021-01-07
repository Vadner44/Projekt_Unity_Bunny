using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class wynik : MonoBehaviour
{
    public Text wynik1;
    public Text wynik2;
    public Text wyn;


    // Start is called before the first frame update
    void Start()
    {
        wynik1.text = PlayerPrefs.GetInt("Best" + 1).ToString();
        wynik2.text = PlayerPrefs.GetInt("Best" + 2).ToString();
        wyn.text = (PlayerPrefs.GetInt("Best" + 1) + PlayerPrefs.GetInt("Best" + 2)).ToString();


    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
