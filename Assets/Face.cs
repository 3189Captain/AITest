using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Face : Align
{
    GameObject target;
    Vector3 direction;

    SteeringOutput getSteering()
    {
        Align align = new Align();
        direction = target.transform.position - character.transform.position;

        if(direction.magnitude == 0)
        {
            SteeringOutput none = new SteeringOutput();
            return none;
        }
        align.target = target;
        align.target.transform.rotation = Quaternion.Euler(0, Mathf.Atan2(-direction.x, direction.z), 0);
        return align.getSteering();
    }
}
