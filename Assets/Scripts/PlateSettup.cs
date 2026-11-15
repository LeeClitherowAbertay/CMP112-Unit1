using TMPro;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class PlateSettup : MonoBehaviour
{
    public bool large = false;

    public int max_health = 1; 
    public int health = 1;

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
    public void _damage(int damage, GameObject player)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
            player.GetComponent<PlayerManager>()._increase_score(1);
        }
    }
}
