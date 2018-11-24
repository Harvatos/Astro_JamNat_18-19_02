using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathPoint : MonoBehaviour{
	
	public bool isLethal = false;

	public PathPoint nextPathPoint;

	public void RotateObjectTowardPath(Transform toRotate)
	{
		toRotate.LookAt(nextPathPoint.transform);
	}

#if UNITY_EDITOR
	private void OnDrawGizmos()
	{
		Gizmos.color = isLethal ? Color.red : Color.blue;
		Gizmos.DrawSphere(transform.position, 0.2f);

		if (nextPathPoint)
		{
			Gizmos.color = Color.magenta;
			Gizmos.DrawLine(transform.position, nextPathPoint.transform.position);
		}
	}
	#endif
}
