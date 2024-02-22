using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aiming : MonoBehaviour
{
	[SerializeField] private GameObject _source;
	[SerializeField] private GameObject _target;
	[SerializeField] private LayerMask _raycastLayer;

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
		if(state == PlayerState.AIMING)
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
		if (!_playerIsAiming) return;
		MoveTarget();
		AimSource();
	}

	void MoveTarget()
	{
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;

		if (Physics.Raycast(ray, out hit, Mathf.Infinity, _raycastLayer))
		{
			Vector3 hoverPoint = hit.point;
			_target.transform.position = hoverPoint;
		}
	}

	void AimSource()
	{
		if(_source != null)
		{
			Vector3 direction = _target.transform.position - _source.transform.position;

			if(direction != Vector3.zero)
			{
				Quaternion lookRot = Quaternion.LookRotation(direction);
				//This is an interesting bit of code that we'll want to look at together Pax
				float offset = lookRot.eulerAngles.y > 100 ? 90+(90-lookRot.eulerAngles.x) : lookRot.eulerAngles.x;
				_source.transform.rotation = Quaternion.Euler(offset, 90f, 0f);
			}
		}
	}
}
