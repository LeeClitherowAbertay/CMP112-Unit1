using UnityEditor.Rendering;
using UnityEngine;

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
    public void _damage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
