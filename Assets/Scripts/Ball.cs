using UnityEngine;
using System.Collections;
public class Ball : MonoBehaviour
{
    public Paddle paddle;
    public bool gameStarted = false;
    private Vector3 paddleVector;
    //Make the min and max speed to be configurable in the editor.
    public float MinimumSpeed = 10;
    public float MaximumSpeed = 20;


    public float MinimumVerticalMovement = 0.5F;

    // Use this for initialization
    void Start()
    {
        //Set the ball on the paddle position
        paddleVector = this.transform.position - paddle.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameStarted)
        {
            this.transform.position = paddle.transform.position + paddleVector;
            if (Input.GetMouseButtonDown(0))
            {
                print("Mouse clicked!");
                gameStarted = true;
                this.GetComponent<Rigidbody2D>().velocity = new Vector2
               (Random.Range(-2.0f, 2.0f), 10f);
                this.GetComponent<TrailRenderer>().enabled = true;
            }
        }
        launchBall();
    }

    public void launchBall()
    {
        //Get current speed and direction
        Vector2 direction = GetComponent<Rigidbody2D>().velocity;
    //float speed = 20f;
    float speed = direction.magnitude;
    direction.Normalize();


         if (direction.x > -MinimumVerticalMovement && direction.x <
         MinimumVerticalMovement)
        {

            //Adjust the x to limit it to the movement left or right
            direction.x = direction.x < 0 ? -MinimumVerticalMovement :
            MinimumVerticalMovement;

            direction.y = direction.y < 0 ? -1 + MinimumVerticalMovement :
            1 - MinimumVerticalMovement;
            //print(direction.x);
            //Apply it back to the ball
            GetComponent<Rigidbody2D>().velocity = direction * speed;
        }

        if (speed<MinimumSpeed || speed> MaximumSpeed)
         {
        //Limit the speed so it always above min en below max
         speed = Mathf.Clamp(speed, MinimumSpeed, MaximumSpeed);
         //Apply the limit

        GetComponent<Rigidbody2D>().velocity = direction* speed;
        }

    }
}