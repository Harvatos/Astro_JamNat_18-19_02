using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BlobCharacter : MonoBehaviour {

	public float transitionSpeed = 2f;

	public PathPoint previousPoint;
	public PathPoint currentPoint;

	public Animator anim;

	private MinMaxVector3 currentPath;
	private LerpValue pathLerp;

	private bool lerpCompleted = false;

	private void Start()
	{
		if(currentPoint)
		{
			previousPoint = currentPoint;
			transform.SetParent(currentPoint.transform, true);
			currentPath = new MinMaxVector3(currentPoint.transform.position, currentPoint.transform.position);
			pathLerp = new LerpValue(1f);
			GameController.instance.AddBlob(this);
			anim.speed = 0.8f;
		}
		else
		{
			Debug.LogError("Blob is not on a PathPoint");
		}
	}

	private void Update()
	{
		pathLerp.AddDelta(Time.deltaTime * transitionSpeed);
		currentPath = new MinMaxVector3(previousPoint.transform.position, currentPoint.transform.position);
		transform.position = currentPath.Lerp(pathLerp.Value);
		if (!lerpCompleted && pathLerp.Value >= 1f)
		{
			lerpCompleted = true;
		}
	}

	private void OnLerpCompleted()
	{
		currentPoint.RotateObjectTowardPath(transform);
	}

	/// <summary>
	/// Called on character movement tick.
	/// </summary>
	[ContextMenu ("Advance On Path")]
	public void AdvanceOnPath()
	{
		currentPoint.ExecutePathBehavior(this);
	}

	/// <summary>
	/// Called before level movement tick. Will kill the character if current point isLethal.
	/// </summary>
	[ContextMenu ("Test Current Point")]
	public void TestCurrentPoint()
	{
		if (currentPoint.isLethal)
		{
			Despawn();
		}
		else
		{
			currentPoint.RotateObjectTowardPath(transform);
		}
	}

	public void Path_GoToNextPoint(PathPoint nextPathPoint)
	{
		anim.SetTrigger("Move");
		lerpCompleted = false;
		currentPath = new MinMaxVector3(currentPoint.transform.position, nextPathPoint.transform.position);
		pathLerp.Zero();
		previousPoint = currentPoint;
		currentPoint = nextPathPoint;
		transform.SetParent(nextPathPoint.transform, true);
	}

	public void Despawn()
	{
		anim.SetTrigger("Despawn");
		GameController.instance.RemoveBlob(this);
	}

}
