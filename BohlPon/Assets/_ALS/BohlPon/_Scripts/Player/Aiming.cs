using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ALS.BohlPon
{
	public class Aiming : MonoBehaviour
	{
		[SerializeField] private GameObject _source; //Ball Launcher
		[SerializeField] private GameObject _target; //Point we want to look at
		[SerializeField] private LayerMask _raycastLayer;

		[SerializeField] private ProjectileLauncher _launcher;

		[SerializeField] private PlayerData _playerData;

		private bool _playerIsAiming = false;

		private void OnEnable()
		{
			_playerData.OnPlayerStateChanged += RecivePlayerState; //subscribe
			RecivePlayerState(_playerData.PlayerState);
		}
		private void OnDisable()
		{
			_playerData.OnPlayerStateChanged -= RecivePlayerState; //unsubscribe
		}

		void RecivePlayerState(PlayerState state)
		{
			if (state == PlayerState.AIMING)
			{
				_playerIsAiming = true;
			}
			else
			{
				_playerIsAiming = false;
			}
		}

		private void Update()
		{
			//! = NOT in C# and we can shorten != true to !nameOfBool
			if (!_playerIsAiming) return;
			// (||) == OR operator
			if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
			{
				_playerData.PlayerState = PlayerState.PENDING;
				//Pass in direction described as a Vector3
				_launcher.LaunchProjectile(_source.transform.forward);
			}
			MoveTarget();
			AimSource();
		}

		void MoveTarget()
		{
			if (_target == null) return;
			//Also get the position of a tapped finger
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;

			if (Physics.Raycast(ray, out hit, Mathf.Infinity, _raycastLayer))
			{
				Vector3 hoverPoint = hit.point; //3 Float compoents usually described as (x, y, z)
				_target.transform.position = hoverPoint;
			}
		}

		void AimSource()
		{
			if (_source == null) return;

			//direction in vector form that is at the source position looking at the target
			Vector3 direction = _target.transform.position - _source.transform.position;

			if (direction != Vector3.zero)
			{
				//Quaternion = Vector4
				Quaternion lookRot = Quaternion.LookRotation(direction);
				//This is an interesting bit of code that we'll want to look at together Pax
				//(variable) = (bool) ? (value to set if bool is true) : (value to set if bool is false)
				float offset = lookRot.eulerAngles.y > 100 ? 90 + (90 - lookRot.eulerAngles.x) : lookRot.eulerAngles.x;
				//Set the offset to euler.x and give euler.y and euler.z a fixed value
				_source.transform.rotation = Quaternion.Euler(offset, 90f, 0f);
			}
		}
	}
}