using UnityEngine;

public class Launcher : MonoBehaviour
{
    public GameObject barral;
    public GameObject plate;

    public int min_rotation;
    public int max_rotation;

    public float min_speed;
    public float max_speed;

    public float min_interval;
    public float max_interval;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (barral == null || plate == null)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {

    }
}
