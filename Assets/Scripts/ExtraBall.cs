using UnityEngine;
using System.Collections;
public class ExtraBall : BasePowerUp
{
    //BallPrefab instantiated when the powerup is picked up
    public GameObject BallPrefab;
    //Make the min and max speed to be configurable in the editor.
    public float MinimumSpeed = 10;
    public float MaximumSpeed = 20;

    public float MinimumVerticalMovement = 0.5F;
    protected override void OnPickup()
    {
        //Call the default behaviour of the base class first
        base.OnPickup();
        print("On pickup Call!");
    }

    void OnCollisionEnter2D(Collision2D c)
    {
        print("Extra Collison");

        if (c.gameObject.tag == "Paddle"){
            print("Extra Collison Paddle");
            launchBall();
        }
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
            direction.x = direction.x < 0 ? -MinimumVerticalMovement :
            MinimumVerticalMovement;


            direction.y = direction.y < 0 ? -1 + MinimumVerticalMovement :
            1 - MinimumVerticalMovement;

            //Apply it back to the ball
            GetComponent<Rigidbody2D>().velocity = direction * speed;
        }
        if (speed < MinimumSpeed || speed > MaximumSpeed)
        {
            //Limit the speed so it always above min en below max
            speed = Mathf.Clamp(speed, MinimumSpeed, MaximumSpeed);

            GetComponent<Rigidbody2D>().velocity = direction * speed;
        }

    }
}