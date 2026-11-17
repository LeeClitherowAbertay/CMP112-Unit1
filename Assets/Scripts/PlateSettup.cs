using TMPro;
using UnityEngine;

public class PlateSettup : MonoBehaviour
{
    public bool large = false;

    public int max_health = 1; 
    public int health = 1;

    //referance to the player
    public GameObject player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //sets wether its a small or large plate
        if (Random.value >= 0.5)
        {
            large = true;
            transform.localScale = transform.localScale * 2;
            max_health = 2;
        }
        health = max_health;
    }

    private void Update()
    {
        //when the game is paused it destroys itself to stop the player from taking further damage
        if (player.GetComponent<PlayerManager>().is_paused)
        {
            Destroy(gameObject);
        }
    }

    public void _damage(int damage)
    {
        //subtracts health to itself
        health -= damage;

        //if its health is zero it kills itself and calls a function to increase the score in the player
        if (health <= 0)
        {
            Destroy(gameObject);
            player.GetComponent<PlayerManager>()._increase_score(1);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        //if it hits the ground it makes the player take damge
        if (collision.gameObject.CompareTag("Ground")){
            player.GetComponent<PlayerManager>()._take_damage(1);
            Destroy(gameObject);
        }
    }
}
