using UnityEngine;

public class cameraController : MonoBehaviour
{
    public float sensex;
    public float sensey;

    float xrotation;
    float yrotation;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        float mousex = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensex;
        float mousey = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensey;

        yrotation += mousex;
        xrotation -= mousey;

        xrotation = Mathf.Clamp(xrotation, -90.0f, 90.0f);

        transform.rotation = Quaternion.Euler(xrotation, yrotation, 0);

    }
}
