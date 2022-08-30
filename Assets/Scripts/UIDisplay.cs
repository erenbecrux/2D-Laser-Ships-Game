using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIDisplay : MonoBehaviour
{
    ScoreKeeper scoreKeeper;
    [SerializeField] Health playerHealth;
    [SerializeField] Slider healthSlider;
    [SerializeField] TextMeshProUGUI scoreText;


    void Awake() 
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
            
    }

    void Start() 
    {
        healthSlider.maxValue = playerHealth.GetCurrentHealth();    
    }



    void Update() 
    {
        healthSlider.value = playerHealth.GetCurrentHealth();
        scoreText.text = scoreKeeper.GetCurrentScore().ToString("0000000");
    }
}
