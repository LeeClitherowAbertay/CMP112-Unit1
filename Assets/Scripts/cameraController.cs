using UnityEngine;

public class cameraController : MonoBehaviour
{
    public float sensex;
    public float sensey;

    float xrotation;
    float yrotation;

    public GameObject player;

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<PlayerManager>().is_paused == false)
        {
            //moves the cammera based on the snensx and sensy and the movement of the players mouse

            float mousex = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensex;
            float mousey = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensey;

            yrotation += mousex;
            xrotation -= mousey;

            xrotation = Mathf.Clamp(xrotation, -90.0f, 90.0f);

            transform.rotation = Quaternion.Euler(xrotation, yrotation, 0);
        }

    }
}
