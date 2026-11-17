using Unity.Mathematics;
using UnityEngine;


public class PlayerShooting : MonoBehaviour
{
    public GameObject camera;

    void Start()
    {
        
    }

    void Update()
    {
        //checks if left click is pressed and if the game isnt paused
        if (Input.GetMouseButtonDown(0) && !gameObject.GetComponent<PlayerManager>().is_paused)
        {

            //casts a ray and then calls a damage function in the plate if it hits one
            RaycastHit hit;

            if (Physics.Raycast(camera.transform.position, camera.transform.forward*100,out hit, Mathf.Infinity))
            {
                if (hit.transform.CompareTag("Plate"))
                {
                    hit.transform.gameObject.GetComponent<PlateSettup>()._damage(1);
                }
            }
        }
    }
}
