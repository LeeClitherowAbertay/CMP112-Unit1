using UnityEngine;

public class Launcher : MonoBehaviour
{
    public GameObject rotator;
    public GameObject plate_pref;

    public int min_rotation;
    public int max_rotation;

    public float rotation_speed;
    private int rotation_direction = 1;

    public float min_shoot_speed;
    public float max_shoot_speed;

    public float min_plate_speed;
    public float max_plate_speed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (rotator == null || plate_pref == null)
        {
            Destroy(gameObject);
        }
        rotator.transform.rotation = Quaternion.Euler(0, 0, min_rotation);

        float time = Random.Range(min_shoot_speed, max_shoot_speed);
        Invoke("_shoot_plate", time);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        float zrotation = rotation_speed * rotation_direction * Time.deltaTime;

        if (rotator.transform.rotation.eulerAngles.z > max_rotation)
        {
            rotator.transform.rotation = Quaternion.Euler(0, 0, max_rotation);
            rotation_direction = -1;
        }
        else if (rotator.transform.rotation.eulerAngles.z < min_rotation)
        {
            rotator.transform.rotation = Quaternion.Euler(0, 0, min_rotation);
            rotation_direction = 1;
        }

        rotator.transform.Rotate(0,0,zrotation);
    }

    private void _shoot_plate()
    {
        Debug.Log("Shoot");
        
        GameObject plate = Instantiate(plate_pref);
        Rigidbody plate_rb = plate.GetComponent<Rigidbody>();

        plate.transform.position = transform.position;

        float plate_speed = Random.Range(min_plate_speed, max_plate_speed);
        plate_rb.AddForce(rotator.transform.up * plate_speed);

        Destroy(plate, 10);

        float time = Random.Range(min_shoot_speed, max_shoot_speed);
        Invoke("_shoot_plate", time);
    }

}
