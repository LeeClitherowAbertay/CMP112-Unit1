using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{

    private int score;
    public Text score_ui;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void _increase_score(int value)
    {
        score += value;
        score_ui.text = "Score: " + score.ToString();
    }
}
