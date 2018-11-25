using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathPoint_Spawn: PathPoint {

	

#if UNITY_EDITOR
	private void OnDrawGizmos()
	{
		Gizmos.color = Color.magenta;
		Gizmos.DrawCube(transform.position, new Vector3(0.5f,0.5f,0.5f));

		if (nextPathPoint)
		{
			Gizmos.color = Color.magenta;
			Gizmos.DrawLine(transform.position, nextPathPoint.transform.position);
		}
	}
#endif
}