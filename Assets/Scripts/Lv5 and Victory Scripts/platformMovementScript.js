#pragma strict

private var moveSpeed = 2.0;
private var bottomBound = -5.0;
private var topBound = 2.25;
private var movingUp = 1.0;

function Update () {

	// if platform is already moving top, and is position is less than the top bound
	if(movingUp == 1 && transform.position.y <= topBound)
	{
		// move platform top
		transform.position.y += moveSpeed * Time.deltaTime;
	}
	// if platform is already moving down or if position is greater than top bound
	else
	{
		// set moveUp Boolean to false
		movingUp = 0.0;
		// move down
		transform.position.y -= moveSpeed * Time.deltaTime;
		
		// if position is less than or equal to down bound, change direction
		if(transform.position.y <= bottomBound)
		{
			movingUp = 1.0;
		}
		
	}



}