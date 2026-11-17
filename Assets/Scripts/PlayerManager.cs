using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{

    private int score;
    private int lives;
    public Text score_ui;
    public Text lives_ui;

    public Text game_over_ui;

    public Button play_button;
    public Button resume_button;
    public Button exit_button;


    public bool is_paused = true;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (is_paused)
            {
                _resume_game();
            }
            {
                _pause_game();
            }
        }
    }

    public void _increase_score(int value)
    {
        score += value;
        score_ui.text = "Score: " + score.ToString();
    }

    public void _take_damage(int value)
    {
        if (lives > 0)
        {
            lives -= 1;
            lives_ui.text = "Lives: " + lives.ToString();
        }
        if (lives <= 0)
        {
            _end_game();
        }
    }

    public void _pause_game()
    {
        is_paused = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;


        exit_button.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        resume_button.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
    }

    public void _resume_game()
    {
        is_paused = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        resume_button.GetComponent<RectTransform>().localScale = new Vector3(0, 0, 0);
        exit_button.GetComponent<RectTransform>().localScale = new Vector3(0, 0, 0);
    }

    public void _end_game()
    {

        game_over_ui.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        play_button.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        exit_button.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);

        is_paused = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

    }

    public void _start_game()
    {
        lives = 3;
        score = 0;
        score_ui.text = "Score: " + score.ToString();
        lives_ui.text = "Lives: " + lives.ToString();

        _resume_game();

        game_over_ui.GetComponent<RectTransform>().localScale = new Vector3(0, 0, 0);
        play_button.GetComponent<RectTransform>().localScale = new Vector3(0,0,0);

    }

    public void _exit_game()
    {
        Application.Quit();
    }

}
