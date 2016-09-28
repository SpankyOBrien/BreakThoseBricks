using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource), typeof(Animation))]
public class Brick : MonoBehaviour
{
    public int maxHits;
    public int timesHit;
    private bool BrickIsDestroyed = false;
    public AudioClip Sound;
    public float PitchStep = 0.05F;
    public float MaxPitch = 1.3F;

    public static float pitch = 1;

    public bool FallDown = false;

    public bool BlockIsDestroyed = false;

    private Vector2 velocity = Vector2.zero;

    // Use this for initialization
    void Start()
    {
        timesHit = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (FallDown && velocity != Vector2.zero)
        {
            Vector2 pos = (Vector2)transform.position;
            pos += velocity * Time.deltaTime;
        }
    }

    void OnBecameInvisible()
    {
        BlockIsDestroyed = true;
        Destroy(gameObject);
    }

    private IEnumerator OnCollisionExit2D(Collision2D c)
    {
        if (timesHit == maxHits)
        {
            print("Destroyed on Exit!");

            print("Play Woggle!");
            GetComponent<Collider2D>().enabled = false;
            //Play the Woggle animation
            GetComponent<Animation>().Play();

            yield return new WaitForSeconds(GetComponent<Animation>()
           ["Woggle"].length);


 if (FallDown)
            {
                print("Falling!");
 velocity = new Vector2(0, Random.Range(1, 12.0F) * -1);
            }
            else
            {
                GetComponent<Renderer>().enabled = false;
            }
            Destroy(gameObject);
        }
        else
        {
            print("Max hits not reached");
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        timesHit++;
        print("Ouch you hit me this many times:" + timesHit);
        print("Playing brick sound!");
        //Increase pitch
        pitch += PitchStep;

        //Limit pitch
        if (pitch > MaxPitch)
            pitch = 1; 
   
 //Apply pitch
        GetComponent<AudioSource>().pitch = pitch;

        //Play it once for this collision hit
        GetComponent<AudioSource>().PlayOneShot(Sound);
        StartCoroutine(OnCollisionExit2D(col));

    }
}