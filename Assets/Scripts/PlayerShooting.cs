using UnityEngine;


public class PlayerController : MonoBehaviour
{
    public float bullet_speed;
    public GameObject bullet_pref;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject bullet = Instantiate(bullet_pref);
            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            bullet.transform.position = transform.position;
            bullet.transform.rotation = transform.rotation;
            rb.AddForce(bullet.transform.forward * bullet_speed, ForceMode.Impulse);
            Destroy(bullet, 5);
        }
    }
}
