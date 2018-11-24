﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

#region Enums

#endregion

#region Structs
[System.Serializable]
public struct MinMax
{
	public float min, max;

	public MinMax (float _min, float _max)
	{
		min = _min;
		max = _max;
	}

	public float Lerp(float t, bool unClamped = false)
	{
		if (!unClamped) { t = Mathf.Clamp01(t); }
		return Mathf.Lerp(min, max, t);
	}

	public float InverseLerp (float value, bool unClamped = false)
	{
		if (!unClamped) { value = Mathf.Clamp(value, min, max); }
		return Mathf.InverseLerp(min, max, value);
	}

	public float RandomValue {get { return Random.Range(min, max); }}
}

[System.Serializable]
public struct MinMaxInt
{
	public int min, max;

	public MinMaxInt (int _min, int _max)
	{
		min = _min;
		max = _max;
	}

	public int Lerp(float t, bool unClamped = false)
	{
		if (!unClamped) { t = Mathf.Clamp01(t); }
		return Mathf.RoundToInt(Mathf.Lerp(min, max, t));
	}

	public float InverseLerp(int value, bool unClamped = false)
	{
		if (!unClamped) { value = Mathf.Clamp(value, min, max); }
		return Mathf.InverseLerp(min, max, value);
	}

	public int RandomValue()
	{
		return Random.Range(min, max + 1);
	}

	public MinMax ToFloats ()
	{
		return new MinMax(min, max);
	}
}

[System.Serializable]
public struct MinMaxVector3
{
	public Vector3 min, max;

	public MinMaxVector3 (Vector3 _min, Vector3 _max)
	{
		min = _min;
		max = _max;
	}

	public Vector3 Lerp(float t, bool unClamped = false)
	{
		return unClamped ? Vector3.LerpUnclamped(min, max, t) : Vector3.Lerp(min, max, t);
	}

	public Vector3 RandomPoint()
	{
		return Lerp(Random.value);
	}
}

public struct LerpValue
{
	private float lerpValue;
	public float Value		{ get{ return lerpValue; } set{ lerpValue = Mathf.Clamp01(value); } }
	public float ExpValue	{ get { return lerpValue * lerpValue; } }

	public LerpValue (float startValue = 0f)
	{
		lerpValue = Mathf.Clamp01(startValue);
	}

	public void Zero ()
		{ lerpValue = 0f; }

	public void One ()
		{ lerpValue = 1f; }
	
	public float AddDelta (float delta)
	{
		lerpValue = Mathf.Clamp01(lerpValue + delta);
		return lerpValue;
	}

	public float Lerp (float a, float b)
		{ return Mathf.Lerp(a, b, lerpValue); }
	public Vector3 Lerp (Vector3 a, Vector3 b)
		{ return Vector3.Lerp(a, b, lerpValue); }
	public Vector2 Lerp (Vector2 a, Vector2 b)
		{ return Vector2.Lerp(a, b, lerpValue); }
	public Quaternion Lerp (Quaternion a, Quaternion b)
		{ return Quaternion.Lerp(a, b, lerpValue); }

	public void LerpTransform (Transform transform, Transform source, Transform target)
	{
		transform.position = Lerp(source.position, target.position);
		transform.rotation = Lerp(source.rotation, target.rotation);
	}
	public void LerpTransform (Transform transform, Transform target)
	{
		transform.position = Lerp(transform.position, target.position);
		transform.rotation = Lerp(transform.rotation, target.rotation);
	}
}
#endregion