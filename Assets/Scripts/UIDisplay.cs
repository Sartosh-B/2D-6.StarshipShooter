using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIDisplay : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] Slider healthBar;
    [SerializeField] Health playerHealth;

    ScoreKeeper scoreKeeper;

    private void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }
    private void Start()
    {

        healthBar.maxValue = playerHealth.GetHealth();
        
    }
    void Update()
    {
        healthBar.value = playerHealth.GetHealth();
        scoreText.text = scoreKeeper.GetCurrentScore().ToString("000000");
    }



}
