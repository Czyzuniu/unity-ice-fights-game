using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject target;
    private Vector3 startingPosition = new Vector3();
    public float moveSpeed = 55.0f;
    void Start()
    {
        startingPosition = this.GetComponent<Rigidbody>().position;
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody targetBody = target.GetComponent<Rigidbody>();
        Vector3 direction = targetBody.position - transform.position;
        this.transform.LookAt(targetBody.position);
        //this.GetComponent<Rigidbody>().AddForce((targetBody.position - transform.position) * moveSpeed * Time.deltaTime, ForceMode.Acceleration);
    }

    void OnCollisionEnter(Collision collisionInfo) {
        Rigidbody myBody = this.GetComponent<Rigidbody>();
        string tag = collisionInfo.collider.tag;
        if (tag == "Water") {
            myBody.position = startingPosition;
            myBody.velocity = Vector3.zero;
            myBody.angularVelocity = Vector3.zero;
        }
    }
}
