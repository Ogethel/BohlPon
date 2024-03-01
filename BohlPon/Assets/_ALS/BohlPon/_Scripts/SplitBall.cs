using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ALS.BohlPon
{
	public class SplitBall : MonoBehaviour
	{
		[SerializeField] private GameObject _prefab;
		[SerializeField] private PlayerData _data;
		private Rigidbody _rb;
		public bool HasTriggered = false;

		const int TRACKED_FRAMES = 14;
		Vector3[] _velocityFrames = new Vector3[TRACKED_FRAMES];
		int _velocityIndex = 0;

		private void OnEnable()
		{
			_rb = GetComponent<Rigidbody>();
		}

		private void Update()
		{
			AddFrame(_rb.velocity);
		}

		void AddFrame(Vector3 velocity)
		{
			_velocityFrames[_velocityIndex] = velocity; //_playerBody.velocity;
			_velocityIndex++;
			_velocityIndex %= TRACKED_FRAMES; //MOD
		}

		Vector3 GetMaxRecentVelocity()
		{
			Vector3 maxVelocity = Vector3.zero;
			float maxMagnitude = 0f;

			foreach (Vector3 velocity in _velocityFrames)
			{
				if (velocity == Vector3.zero) continue;

				float magnitude = velocity.sqrMagnitude;
				if (magnitude > maxMagnitude)
				{
					maxVelocity = velocity;
					maxMagnitude = magnitude;
				}
			}

			return maxVelocity;
		}

		private void OnCollisionEnter(Collision collision)
		{
			if (HasTriggered) return;
			
			GameObject go = Instantiate(_prefab, transform.position, transform.rotation);
			Rigidbody rb = go.GetComponent<Rigidbody>();
			SplitBall splitScript = go.GetComponent<SplitBall>();
			//if(rb) StartCoroutine(DelaySettingVelocity(rb));
			if (rb) rb.AddForce(GetMaxRecentVelocity(), ForceMode.VelocityChange);
			if (splitScript) splitScript.HasTriggered = true;
			HasTriggered = true;
		}

		//IEnumerator DelaySettingVelocity(Rigidbody rb)
		//{
		//	yield return new WaitForFixedUpdate();
		//	Vector3 newVelocity = _rb.velocity.normalized * GetMaxRecentVelocity().magnitude;
		//	rb.AddForce(newVelocity, ForceMode.VelocityChange);
		//}
	}
}

