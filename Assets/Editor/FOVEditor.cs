using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor (typeof(PlayerFOV))]
public class FOVEditor : Editor
{
	private void OnSceneGUI()
	{
		PlayerFOV fow = (PlayerFOV)target;
		Handles.color = Color.white;
		Handles.DrawWireArc(fow.transform.position, Vector3.right, Vector3.forward, 360, fow.ViewRadius);
		Vector3 viewAngleA = fow.DirFromAngle(-fow.ViewAngle / 2, false);
		Vector3 viewAngleB = fow.DirFromAngle(fow.ViewAngle / 2, false);

		Handles.DrawLine(fow.transform.position, fow.transform.position + viewAngleA * fow.ViewRadius);
		Handles.DrawLine(fow.transform.position, fow.transform.position + viewAngleB * fow.ViewRadius);

		Handles.color = Color.red;
		foreach (Transform visibleTarget in fow.visibleTargets)
		{
			if(visibleTarget)
				Handles.DrawLine(fow.transform.position, visibleTarget.position);
		}
	}
}
