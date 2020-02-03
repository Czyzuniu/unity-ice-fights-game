using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody rb;
    private readonly KeyCode DOWN = KeyCode.S;
    private readonly KeyCode UP = KeyCode.W;
    private readonly KeyCode LEFT = KeyCode.A;
    private readonly KeyCode RIGHT = KeyCode.D;
    //private readonly KeyCode JUMP = KeyCode.Space;
    public readonly float FORWARD_SPEED = 750.0f;
    public readonly float SIDE_SPEED = 150.0f;
    public readonly float UP_SPEED = 500f;
    private readonly int FPS = 60;
    private float distToGround;
    private Vector3 startingPosition = new Vector3();

    void Start()
    {
        distToGround = GetComponent<Collider>().bounds.extents.y;
        startingPosition = rb.position;
    }

    // Update is called once per frame
    void FixedUpdate() {
        HandlePlayerMovement();
    }

    void HandlePlayerMovement() {
        float forwardDeltaSpeed = FORWARD_SPEED * FPS * Time.deltaTime;
        float sideDeltaSpeed = SIDE_SPEED * FPS * Time.deltaTime;
        if (Input.GetKey(DOWN)) {
            rb.AddForce(-transform.forward * forwardDeltaSpeed);
        }
        if (Input.GetKey(UP)) {
            rb.AddForce(transform.forward * forwardDeltaSpeed);
        }
        if (Input.GetKey(LEFT)) {
            Vector3 m_EulerAngleVelocity = new Vector3(0, -sideDeltaSpeed, 0);
            Quaternion deltaRotation = Quaternion.Euler(m_EulerAngleVelocity * Time.deltaTime);
            rb.MoveRotation(rb.rotation * deltaRotation);
        }
        if (Input.GetKey(RIGHT)) {
            Vector3 m_EulerAngleVelocity = new Vector3(0, sideDeltaSpeed, 0);
            Quaternion deltaRotation = Quaternion.Euler(m_EulerAngleVelocity * Time.deltaTime);
            rb.MoveRotation(rb.rotation * deltaRotation);
        }
    }

    bool IsGrounded() {
        return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.5f);
    }

    void OnCollisionEnter(Collision collisionInfo) {
        Debug.Log(collisionInfo);
        GameObject collider = collisionInfo.gameObject;
        if (collider.tag == "Water") {
            ResetPlayer();
        } else if (collider.tag == "CannonBall") {

        }
    }

    void ResetPlayer() {
        this.rb.position = startingPosition;
        this.rb.velocity = Vector3.zero;
        this.rb.angularVelocity = Vector3.zero;
    }

}
