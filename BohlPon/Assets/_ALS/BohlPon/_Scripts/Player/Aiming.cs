using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aiming : MonoBehaviour
{
	[SerializeField] private GameObject _source;
	[SerializeField] private GameObject _target;

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
}
