using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookWhereYoureGoing : Align
{
	SteeringOutput getSteering()
	{
		Align align = new Align();
		SteeringOutput none = new SteeringOutput();
		Vector3 velocity = character.linearVelocity;
		if(velocity.magnitude == 0)
		{
			return none;
		}

		target.transform.rotation = Quaternion.Euler(0, Mathf.Atan2(velocity.x, velocity.z), 0);
		return align.getSteering();
	}
}
