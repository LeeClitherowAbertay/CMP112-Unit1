using TMPro;
using UnityEngine;

public class PlateSettup : MonoBehaviour
{
    public bool large = false;

    public int max_health = 1; 
    public int health = 1;

    public GameObject player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
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
        if (player.GetComponent<PlayerManager>().is_paused)
        {
            Destroy(gameObject);
        }
    }

    public void _damage(int damage, GameObject player)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
            player.GetComponent<PlayerManager>()._increase_score(1);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground")){
            player.GetComponent<PlayerManager>()._take_damage(1);
            Destroy(gameObject);
        }
    }
}
