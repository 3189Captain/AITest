using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Align 
{
	public Kinematic character;
	public GameObject target;

	float maxAngularAcceleration = 200f;
	float angularAcceleration;
	float maxRotation = 10f;
	float targetRotation;
	float targetRadius = 0.01f;
	float slowRadius = 0.1f;
	float timeToTarget = 0.4f;
	float currentRotation;
	float rotationSize;
	public SteeringOutput getSteering()
	{
		SteeringOutput result = new SteeringOutput();
		currentRotation = Mathf.DeltaAngle(character.transform.rotation.y, target.transform.rotation.y);
		rotationSize = Mathf.Abs(currentRotation);

		if(rotationSize < targetRadius)
		{
			result.angular = 0;
		}
		if(rotationSize > slowRadius)
		{
			targetRotation = maxRotation;
		}
		else
		{
			targetRotation = maxRotation * rotationSize / slowRadius;
		}
		targetRotation *= currentRotation / rotationSize;

		result.angular = targetRotation - character.angularVelocity;
		result.angular /= timeToTarget;

		angularAcceleration = Mathf.Abs(result.angular);
		if(angularAcceleration > maxAngularAcceleration)
		{
			result.angular /= angularAcceleration;
			result.angular *= maxAngularAcceleration;
		}
		return result;
	}
}
