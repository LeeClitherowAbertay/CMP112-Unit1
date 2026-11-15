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
        if (Input.GetMouseButtonDown(0))
        {

            RaycastHit hit;

            if (Physics.Raycast(camera.transform.position, camera.transform.forward*100,out hit, Mathf.Infinity))
            {
                if (hit.transform.CompareTag("Plate"))
                {
                    hit.transform.gameObject.GetComponent<PlateSettup>()._damage(1,gameObject);
                }
            }
        }
    }
}
