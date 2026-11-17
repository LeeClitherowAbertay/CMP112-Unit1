using UnityEngine;
using UnityEngine.PlayerLoop;

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

    public GameObject player;

    private bool is_shooting = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (rotator == null || plate_pref == null || player == null)
        {
            Destroy(gameObject);
        }
        rotator.transform.rotation = Quaternion.Euler(0, 0, min_rotation);

        float time = Random.Range(min_shoot_speed, max_shoot_speed);
        Invoke("_stop_shooting", time);
    }

    // Update is called once per frame
    void Update()
    {
        if (!is_shooting && !player.GetComponent<PlayerManager>().is_paused)
        {
            _shoot_plate();
        }
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

        is_shooting = true;
        
        GameObject plate = Instantiate(plate_pref);
        Rigidbody plate_rb = plate.GetComponent<Rigidbody>();
        PlateSettup plate_su = plate.GetComponent<PlateSettup>();

        plate_su.player = player;

        plate.transform.position = transform.position;

        float plate_speed = Random.Range(min_plate_speed, max_plate_speed);
        plate_rb.AddForce(rotator.transform.up * plate_speed);

        Destroy(plate, 10);

        float time = Random.Range(min_shoot_speed, max_shoot_speed);
        Invoke("_stop_shooting", time);
    }
    private void _stop_shooting()
    {
        is_shooting = false;
    }
}
