using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplePiston : MonoBehaviour, ITick {

	public PathPoint targetPoint;

    void Start()
	{
        GameController.instance.AddTickObject(this);
    }

    public void Tick()
	{
        //CALL ANIM
    }

    

}

