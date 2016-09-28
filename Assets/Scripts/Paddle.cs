using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class Paddle : MonoBehaviour
{
    public int i = 0;
    //Make the AudioClip configurable in the editor
    public AudioClip Sound;

    // Use this for initialization
    void Start()
    {
        print("This is my first Unity script!");
    }

    // Update is called once per frame
    void Update()
    {
        //print(Input.mousePosition);
        //Set variable for current position
        Vector3 paddlePos = new Vector3(8f, this.transform.position.y, 0f);
        //Get mouse position
        float mousePos = Input.mousePosition.x / Screen.width * 8;
        //Set new mouse X position
        paddlePos.x = Mathf.Clamp(mousePos, 0.5f, 7.5f);
        //Change paddle to match new X position
        this.transform.position = paddlePos;
    }

 void OnCollisionEnter2D(Collision2D c)
    {
        //Change the sound pitch if a slowdown powerup has been picked up
        GetComponent<AudioSource>().pitch = Time.timeScale;

        //Play it once for this collision hit
        GetComponent<AudioSource>().PlayOneShot(Sound);
    }
}