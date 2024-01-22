using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float rotateSpeed = 200.0f;
    private float minY = .5f;

    void Update()
    {
        MoveCamera();
        if (Input.GetMouseButton(2)) // Middle mouse button is index 2
        {
            RotateCamera();
        }

        // Change camera height based on Space (positive) or left Control (negative)
        float yChange = 0f;

        if (Input.GetKey(KeyCode.Space))
        {
            yChange = moveSpeed;
        }
        else if (Input.GetKey(KeyCode.LeftControl))
        {
            yChange = -moveSpeed;
        }

        // Apply y-position change
        ChangeCameraHeight(yChange * Time.deltaTime);
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

        transform.position = position;
    }

    void RotateCamera()
    {
        float mouseX = Input.GetAxis("Mouse X") * rotateSpeed * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * rotateSpeed * Time.deltaTime;

        transform.Rotate(Vector3.up, mouseX, Space.World);
        transform.Rotate(Vector3.right, -mouseY, Space.Self);
    }

    void ChangeCameraHeight(float yChange)
    {
        Vector3 position = transform.position;
        position.y = Mathf.Max(minY, position.y + yChange);
        transform.position = position;
    }
}
