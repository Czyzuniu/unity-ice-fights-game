using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBallScript : MonoBehaviour
{

    public List<AudioClip> audioList;
    public AudioSource audioSource;
    public GameObject ball;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision collisionInfo) {
        string tag = collisionInfo.collider.tag;
        if (tag == "Player") {
            int index = RandomNumber(0, audioList.Count);
            audioSource.clip = audioList[index];
            audioSource.Play();
        } else if (tag == "Water") {
            Destroy(ball);
        }
    }

    // Generate a random number between two numbers  
    public int RandomNumber(int min, int max) {
        System.Random random = new System.Random();
        return random.Next(min, max);
    }
}
