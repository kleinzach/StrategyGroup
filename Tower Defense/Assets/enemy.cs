using UnityEngine;
using System.Collections;

public class enemy : MonoBehaviour {
	
	public int horizVelocity;							// The horizontal velocity of the enemy
	public float x_high;								// The upper limit of the enemy's movement
	public float x_low;									// The lower limit of the enemy's movement
	public bool movingRight = true;						// Is the enemy moving right?
	public int vertVelocity;							// the vertical velocity of the enemy
	public float y_high;								// the upper limit of the enemy's movement	
	public float y_low;									// the lower limit of the enemy's movement
	public bool movingUp = true;						// is the enemy moving up?
	public int hitsTilDead;
	
	// Update is called once per frame
	void Update () {
	
	// Horizontal Movement		
		// If the platform is below the right limit and is moving right, it moves right
		if (transform.position.x < x_high && movingRight)
			transform.Translate(horizVelocity * Time.deltaTime, 0, 0);
		
		// If the platform is above the lower limit and is not moving right, it moves left
		if (transform.position.x > x_low && !movingRight)
			transform.Translate(-horizVelocity * Time.deltaTime, 0, 0);			
		
		// At the limits, movingRight is switched
		if (transform.position.x >= x_high || transform.position.x <= x_low)
			movingRight = !movingRight;
		
	//Vertical movement
		// If the platform is below the lower limit and is moving up, it moves up
		if (transform.position.y < y_high && movingUp)
			transform.Translate(0, vertVelocity * Time.deltaTime, 0);
		
		// If the platform is above the bottom limit and is not moving up, it moves down
		if (transform.position.y > y_low && !movingUp)
			transform.Translate(0, -vertVelocity * Time.deltaTime, 0);
		
		// At the limits movingUp is switched
		if (transform.position.y >= y_high || transform.position.y <= y_low)
			movingUp = !movingUp;
		
	// Enemy has been destroyed	
		if (hitsTilDead <= 0)
			Destroy (gameObject);	
	}
	
	void GotHit () {
		hitsTilDead--;
	}
}
