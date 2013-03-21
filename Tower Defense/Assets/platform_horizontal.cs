// Tim Sesler
// tds45

using UnityEngine;
using System.Collections;

public class platform_horizontal : MonoBehaviour {
	
	public int velocity;								// The velocity of the platform
	public float x_high;								// The upper limit of the platform's movement
	public float x_low;									// The lower limit of the platform's movement
	public bool movingRight = true;						// Is the platform moving right?
	
	// Update is called once per frame
	void Update () {
		
		// If the platform is below the right limit and is moving right, it moves right
		if (transform.position.x < x_high && movingRight)
			transform.Translate(velocity * Time.deltaTime, 0, 0);
		
		// If the platform is above the lower limit and is not moving right, it moves left
		if (transform.position.x > x_low && !movingRight)
			transform.Translate(-velocity * Time.deltaTime, 0, 0);			
		
		// At the limits, movingRight is switched
		if (transform.position.x >= x_high || transform.position.x <= x_low)
			movingRight = !movingRight;
	}
}
