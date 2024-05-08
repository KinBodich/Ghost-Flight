using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFOV : MonoBehaviour
{
	[SerializeField] private float _viewRadius;
	[SerializeField] [Range(0, 360)] private float _viewAngle;

	[SerializeField] private LayerMask targetMask;
	[SerializeField] private LayerMask obstacleMask;

	[HideInInspector] public List<Transform> visibleTargets = new List<Transform>();

	public float ViewRadius => _viewRadius;

	public float ViewAngle => _viewAngle;

	public bool IsVisible => visibleTargets.Count > 0;

	private void Start()
	{
		StartCoroutine("FindTargetsWithDelay", 0.2f);
	}


	private IEnumerator FindTargetsWithDelay(float delay)
	{
		while (true)
		{
			yield return new WaitForSeconds(delay);
			FindVisibleTargets();
		}
	}

	private void FindVisibleTargets()
	{
		visibleTargets.Clear();
		Collider[] targetsInViewRadius = Physics.OverlapSphere(transform.position, _viewRadius, targetMask);

		for (int i = 0; i < targetsInViewRadius.Length; i++)
		{
			Transform target = targetsInViewRadius[i].transform;
			Vector3 dirToTarget = (target.position - transform.position).normalized;
			if (Vector3.Angle(transform.forward, dirToTarget) < _viewAngle / 2)
			{
				float dstToTarget = Vector3.Distance(transform.position, target.position);

				if (!Physics.Raycast(transform.position, dirToTarget, dstToTarget, obstacleMask))
				{
					visibleTargets.Add(target);
				}
			}
		}
	}


	public Vector3 DirFromAngle(float angleInDegrees, bool angleIsGlobal)
	{
		if (!angleIsGlobal)
		{
			angleInDegrees -= transform.eulerAngles.x;
		}
		return new Vector3(0, Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
	}
}
