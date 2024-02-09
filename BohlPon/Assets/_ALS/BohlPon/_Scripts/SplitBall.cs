using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ALS.BohlPon
{
	public class SplitBall : MonoBehaviour
	{
		[SerializeField] GameObject _prefab;
		[SerializeField] bool _hasTriggered = false;

		private void OnCollisionEnter(Collision collision)
		{
			if (_hasTriggered) return;
			Instantiate(_prefab, transform.position, transform.rotation);
			_hasTriggered = true;
		}
	}
}

