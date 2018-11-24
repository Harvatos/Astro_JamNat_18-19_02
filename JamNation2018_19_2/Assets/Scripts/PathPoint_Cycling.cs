using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathPoint_Cycling : PathPoint, BasicRythmed {

	public List<PathPoint> pathCycle;

	private int iterator = 0;

	private void Start()
	{
		//Add to Tick event
	}

	[ContextMenu("Tick")]
	public void Tick()
	{
		iterator++;
		if (iterator > pathCycle.Count - 1)
		{ iterator = 0; }
		nextPathPoint = pathCycle[iterator];
	}
}