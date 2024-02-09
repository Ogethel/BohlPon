using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplitBall : MonoBehaviour
{
	[SerializeField] bool _hasTriggered = false;

	private void OnCollisionEnter(Collision collision)
	{
		if (_hasTriggered) return;
		GameObject ball = this.gameObject;
		Instantiate(ball);
		_hasTriggered = true;
	}
}
