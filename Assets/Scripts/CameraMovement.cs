using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform cameraTransform;
    public Rigidbody playerBody;
    public float followSpeed;
    // Start is called before the first frame update
    void Start()
    {
        followSpeed = 10.0f;
    }

    // Update is called once per frame
    void Update()
    {
        cameraTransform.position = Vector3.Lerp(transform.position, new Vector3(playerBody.position.x,cameraTransform.position.y,cameraTransform.position.z), Time.deltaTime * followSpeed);
    }
}
