using UnityEngine;

public class CameraMovementScript : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float rotateSpeed = 200.0f;
    private float minY = 1.0f;

    void Update()
    {
        MoveCamera();
        if (Input.GetMouseButton(2)) // Middle mouse button is index 2
        {
            RotateCamera();
        }
    }

    void MoveCamera()
    {
        Vector3 position = transform.position;

        if (Input.GetKey(KeyCode.W))
        {
            position += transform.forward * moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            position -= transform.forward * moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            position -= transform.right * moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            position += transform.right * moveSpeed * Time.deltaTime;
        }

        position.y = Mathf.Max(position.y, minY);
        transform.position = position;
    }

    void RotateCamera()
    {
        float mouseX = Input.GetAxis("Mouse X") * rotateSpeed * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * rotateSpeed * Time.deltaTime;

        transform.Rotate(Vector3.up, mouseX, Space.World);
        transform.Rotate(Vector3.right, -mouseY, Space.Self);

        // Optional: Clamp vertical rotation (pitch) if needed
    }
}
