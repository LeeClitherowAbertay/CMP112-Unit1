using UnityEngine;
using UnityEngine.PlayerLoop;

public class Launcher : MonoBehaviour
{
    //the object that will be rotated
    public GameObject rotator;
    //the plates that will be launched
    public GameObject plate_pref;

    //rotation limits
    public int min_rotation;
    public int max_rotation;

    //rotation speed and direction
    public float rotation_speed;
    private int rotation_direction = 1;

    //the range of time between shots
    public float min_shoot_speed;
    public float max_shoot_speed;

    //the range of speed the plates get launched at
    public float min_plate_speed;
    public float max_plate_speed;

    //player referance
    public GameObject player;

    //a check to see if another plater can be shot
    private bool is_shooting = true;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //kills the objects if these arent set to ensure the do get set
        if (rotator == null || plate_pref == null || player == null)
        {
            Destroy(gameObject);
        }

        // sets the rotation to minimum to ensure its never out of bounds
        rotator.transform.rotation = Quaternion.Euler(0, 0, min_rotation);

        // allows for the first shot to be made
        float time = Random.Range(min_shoot_speed, max_shoot_speed);
        Invoke("_stop_shooting", time);
    }

    // Update is called once per frame
    void Update()
    {
        //checks if the games is paused and if its not already shooting
        if (!is_shooting && !player.GetComponent<PlayerManager>().is_paused)
        {
            _shoot_plate();
        }
    }

    private void FixedUpdate()
    {

        //swaps the direction of rotation if it goes over/under the respective rotation limits
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

        //set the amount the rotator needs to rotate and rotates it
        float zrotation = rotation_speed * rotation_direction * Time.deltaTime;

        rotator.transform.Rotate(0,0,zrotation);
    }

    private void _shoot_plate()
    {
        //spawns a plate and the applies a force to it based on the roatators roatation

        is_shooting = true;
        
        GameObject plate = Instantiate(plate_pref);
        Rigidbody plate_rb = plate.GetComponent<Rigidbody>();
        PlateSettup plate_su = plate.GetComponent<PlateSettup>();

        plate_su.player = player;

        plate.transform.position = transform.position;

        float plate_speed = Random.Range(min_plate_speed, max_plate_speed);
        plate_rb.AddForce(rotator.transform.up * plate_speed);


        //kills the plate after 10 seconds
        Destroy(plate, 10);

        //sets the amount of time for the next shot
        float time = Random.Range(min_shoot_speed, max_shoot_speed);
        Invoke("_stop_shooting", time);
    }
    private void _stop_shooting()
    {
        //sets shooting to false to allow the launcher to shoot again
        is_shooting = false;
    }
}
