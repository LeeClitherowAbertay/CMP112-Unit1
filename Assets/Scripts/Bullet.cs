using UnityEngine;

public class Bullet : MonoBehaviour
{

    public string target;

    private int damage = 1;
    private Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(target))
        {
            PlateSettup plate = other.GetComponent<PlateSettup>();
            if (plate != null)
            {
                plate._damage(damage);
            }
        }
    }

    public void _set_damage(int value)
    {
        damage = value;
    }
}
