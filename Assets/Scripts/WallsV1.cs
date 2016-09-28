using UnityEngine;
using System.Collections;
[RequireComponent(typeof(AudioSource))]
public class WallsV1 : MonoBehaviour
{
    //Make the AudioClip and Pitch configurable in the editor
    public AudioClip Sound;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnCollisionEnter2D(Collision2D col)
    {
        print("Ouch you hit my wall!");

        //Play it once for this collision hit
        GetComponent<AudioSource>().PlayOneShot(Sound);
    }
}