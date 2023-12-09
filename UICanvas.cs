using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class UICanvas : MonoBehaviour {

    [Header("Health")]
    [SerializeField] private Health playerHealth;
    [SerializeField] private Slider healthSlider;
    [Header("Score")]
    [SerializeField] private TextMeshProUGUI scoreText;
    private ScoreKeeper scoreKeeper;

    private void Awake() {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    private void Start() {
        healthSlider.maxValue = playerHealth.GetHealth();
    }

    private void Update() {
        healthSlider.value = playerHealth.GetHealth();
        scoreText.text = scoreKeeper.GetScore().ToString("000000000");
    }
}
