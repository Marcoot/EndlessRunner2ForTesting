using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform cameraTarget;
    public Vector3 offset = new Vector3(0, 0.5f,-10.0f);

    private void LateUpdate()
    {
        Vector3 desiredPosition = cameraTarget.position + offset;
        desiredPosition.x = 0;
        transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime);
    }
}
