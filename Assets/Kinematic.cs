using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kinematic : MonoBehaviour
{
	public Vector3 linearVelocity;
	public float angularVelocity;
	public GameObject target;
	public int mode;
	SteeringOutput steering;

	public void setSeek()
	{
		mode = 0;
	}
	public void setFlee()
	{
		mode = 1;
	}
	public void setArrive()
	{
		mode = 2;
	}
	public void setAlign()
	{
		mode = 3;
	}
	public void setFace()
	{
		mode = 4;
	}
	public void setLook()
	{
		mode = 5;
	}

    // Update is called once per frame
    void Update()
    {
		//update position and rotation
		transform.position += linearVelocity * Time.deltaTime;
		transform.eulerAngles += new Vector3(0, angularVelocity * Time.deltaTime, 0);

		//update linear and angular velocities
		switch(mode)
		{
			case 0:
				Seek mySeek = new Seek();
				mySeek.character = this;
				mySeek.target = target;
				steering = mySeek.getSteering();
				linearVelocity += steering.linear * Time.deltaTime;
				angularVelocity += steering.angular * Time.deltaTime;
				Debug.Log("Seek");
				break;
			case 1:
				Flee myFlee = new Flee();
				myFlee.character = this;
				myFlee.target = target;
				steering = myFlee.getSteering();
				linearVelocity += steering.linear * Time.deltaTime;
				angularVelocity += steering.angular * Time.deltaTime;
				Debug.Log("Flee");
				break;
			case 2:
				Arrive myArrive = new Arrive();
				myArrive.character = this;
				myArrive.target = target;
				steering = myArrive.getSteering();
				linearVelocity += steering.linear * Time.deltaTime;
				angularVelocity += steering.angular * Time.deltaTime;
				Debug.Log("Arrive");
				break;
			case 3:
				Align myAlign = new Align();
				myAlign.character = this;
				myAlign.target = target;
				steering = myAlign.getSteering();
				linearVelocity += steering.linear * Time.deltaTime;
				angularVelocity += steering.angular * Time.deltaTime;
				Debug.Log("Align");
				break;
			case 4:
				Face myFace = new Face();
				myFace.character = this;
				myFace.target = target;
				steering = myFace.getSteering();
				linearVelocity += steering.linear * Time.deltaTime;
				angularVelocity += steering.angular * Time.deltaTime;
				Debug.Log("Face");
				break;
			case 5:
				LookWhereYoureGoing myLook = new LookWhereYoureGoing();
				myLook.character = this;
				myLook.target = target;
				steering = myLook.getSteering();
				linearVelocity += steering.linear * Time.deltaTime;
				angularVelocity += steering.angular * Time.deltaTime;
				Debug.Log("Look");
				break;
		}
    }
}
