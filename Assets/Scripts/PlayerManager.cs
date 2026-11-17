using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{

    //player score and lives
    private int score;
    private int lives;

    //UI referances
    public Text score_ui;
    public Text lives_ui;

    public Text game_over_ui;

    public Button play_button;
    public Button resume_button;
    public Button exit_button;

    //varaible used to disable things when the game need to be paused
    public bool is_paused = true;


    // Update is called once per frame
    void Update()
    {
        //if tab is pressed it pauses or resumes the game
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

    //increase score function to set the ui and update the variable
    public void _increase_score(int value)
    {
        score += value;
        score_ui.text = "Score: " + score.ToString();
    }

    //damge function to set the ui and update the variable
    public void _take_damage(int value)
    {
        if (lives > 0)
        {
            lives -= 1;
            lives_ui.text = "Lives: " + lives.ToString();
        }
        //calls the end game function to end the game if the player lives hits 0
        if (lives <= 0)
        {
            _end_game();
        }
    }

    //pauses the game when tab is pressed
    public void _pause_game()
    {
        //frees the mouse to interact with buttons and shows the ui for the pause menu
        is_paused = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;


        exit_button.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        resume_button.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
    }

    //resmumes the game when tab or the resume button is pressed
    public void _resume_game()
    {
        //locks the mouse for camera movement and hides the pause menu UI
        is_paused = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        resume_button.GetComponent<RectTransform>().localScale = new Vector3(0, 0, 0);
        exit_button.GetComponent<RectTransform>().localScale = new Vector3(0, 0, 0);
    }

    //for when all lives were lost
    public void _end_game()
    {

        //frees the mouse to interact with buttons and shows the ui for the endd game menu 
        is_paused = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        game_over_ui.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        play_button.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        exit_button.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);

    }

    //for when the play button is pressed
    public void _start_game()
    {
        //resets the lives and score and updates the ui for them
        lives = 3;
        score = 0;
        score_ui.text = "Score: " + score.ToString();
        lives_ui.text = "Lives: " + lives.ToString();

        //locks the mouse for camera movement and hides the start/gameover ui menu UI
        is_paused = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        game_over_ui.GetComponent<RectTransform>().localScale = new Vector3(0, 0, 0);
        play_button.GetComponent<RectTransform>().localScale = new Vector3(0,0,0);
        exit_button.GetComponent<RectTransform>().localScale = new Vector3(0, 0, 0);

    }

    //exits the game when the exit button is pressed
    public void _exit_game()
    {
        Application.Quit();
    }

}
