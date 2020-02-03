using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonScript : MonoBehaviour
{
    public GameObject cannonBall;
    public Rigidbody target;
    public int SHOOTING_SPEED = 150;
    public AudioSource shootingSound;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("StartShootingRoutine", 5.0f);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.LookAt(target.position);
    }

    void ShootCannon() {
        RaycastHit hitInfo;
        Vector3 rayDirection = target.position - transform.position;
        if (Physics.Raycast(transform.position, rayDirection, out hitInfo)) {
            Debug.Log(hitInfo.collider.tag);
            if (hitInfo.collider.tag == "Player") {
                shootingSound.Play(0);
                GameObject cannonProjectile = Instantiate(cannonBall, this.transform.position, Quaternion.identity);
                cannonProjectile.GetComponent<Rigidbody>().AddForce((target.position - transform.position) * SHOOTING_SPEED * Time.deltaTime, ForceMode.Impulse);
            } else {
                Debug.Log("Not shooting because there is something in the way.");
            }
        }
    }

    void StartShootingRoutine() {
        StartCoroutine("StartShooting");
    }

    IEnumerator StartShooting() {
        for (; ; ) {
            ShootCannon();
            yield return new WaitForSeconds(3.0f);
        }
    }
}
