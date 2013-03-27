// Tim Sesler
// tds45

using UnityEngine;
using System.Collections;

public class platform_vertical : MonoBehaviour {

	public int velocity;						// the velocity of the platform
	public float y_high;						// the upper limit of the platform's movement	
	public float y_low;							// the lower limit of the platform's movement
	public bool movingUp = true;				// is the platform moving up?
	
	// Update is called once per frame
	void Update () {
		
		// If the platform is below the lower limit and is moving up, it moves up
		if (transform.position.y < y_high && movingUp)
			transform.Translate(0, velocity * Time.deltaTime, 0);
		
		// If the platform is above the bottom limit and is not moving up, it moves down
		if (transform.position.y > y_low && !movingUp)
			transform.Translate(0, -velocity * Time.deltaTime, 0);
		
		// At the limits movingUp is switched
		if (transform.position.y >= y_high || transform.position.y <= y_low)
			movingUp = !movingUp;
	}
}
