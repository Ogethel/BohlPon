using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ALS.BohlPon
{
	public class SplitBall : MonoBehaviour
	{
		[SerializeField] GameObject _prefab;
		public bool HasTriggered = false;

		private void OnCollisionEnter(Collision collision)
		{
			if (HasTriggered) return;
			GameObject go = Instantiate(_prefab, transform.position, transform.rotation);
			SplitBall splitScript = go.GetComponent<SplitBall>();
			if (splitScript) splitScript.HasTriggered = true;
			HasTriggered = true;
		}
	}
}

