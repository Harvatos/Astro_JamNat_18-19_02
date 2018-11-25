using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathPoint_Cycling : PathPoint, ITick {

	public List<PathPoint> pathCycle;

	private int iterator = 0;

	private void Start()
	{
		GameController.instance.AddTickObject(this);
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