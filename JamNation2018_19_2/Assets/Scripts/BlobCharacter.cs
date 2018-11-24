using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlobCharacter : MonoBehaviour {

	public PathPoint currentPoint;

	private MinMaxVector3 currentPath;

	private void Start()
	{
		if(currentPoint)
		{
			transform.SetParent(currentPoint.transform, true);
		}
		else
		{
			Debug.LogError("Blob is not on PathPoint");
		}
	}

	private void Update()
	{
		
	}

	public void AdvanceOnPath()
	{
		
	}

	public void Path_GoToNextPoint(PathPoint nextPathPoint)
	{
		currentPoint = nextPathPoint;
		transform.SetParent(nextPathPoint.transform, true);
	}

}
