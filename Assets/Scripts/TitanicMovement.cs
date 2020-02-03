using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitanicMovement : MonoBehaviour
{
    public float SPEED = 5.5f;
    private Vector3 defaultPos;
    // Start is called before the first frame update
    void Start()
    {
        defaultPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(-SPEED, 0, 0) * Time.deltaTime;

        if (transform.position.x < -1100) {
            transform.position = new Vector3(1100, defaultPos.y, defaultPos.z);
        }
    }
}
