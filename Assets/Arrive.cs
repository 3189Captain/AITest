using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrive
{
	public Kinematic character;
	public GameObject target;

	float maxAcceleration = 2f;
	float maxSpeed = 10f;
	float targetRadius = 10f;
	float slowRadius = 20f;

	Vector3 direction;
	float targetSpeed;
	float distance;
	Vector3 targetVelocity;
	float timeToTarget = 0.4f;

	public SteeringOutput getSteering()
	{
		SteeringOutput result = new SteeringOutput();
		//result.linear = new Vector3(0, 0, 1);
		//result.angular = 5f;

		//get direction to target
		direction = target.transform.position - character.transform.position;
		distance = direction.magnitude;
		//give full accel
		if(distance < targetRadius)
		{
			result.linear = Vector3.zero;
		} 
		else if (distance > slowRadius)
		{
			targetSpeed = maxSpeed;
		}
		else 
		{
			targetSpeed = maxSpeed * distance / slowRadius;
		}
		//target velocity combines speed and direction
		targetVelocity = direction;
		targetVelocity.Normalize();
		targetVelocity *= targetSpeed;
		//acceleration tries to get to target velocity
		result.linear = targetVelocity - character.linearVelocity;
		result.linear /= timeToTarget;
		//check if accel is too fast
		if(result.linear.magnitude > maxAcceleration)
		{
			result.linear.Normalize();
			result.linear *= maxAcceleration;
		}

		result.angular = 0;
		return result;
	}
}
