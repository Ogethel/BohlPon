using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ALS.BohlPon
{
	public class WIPManager : MonoBehaviour
	{
		[SerializeField] private PlayerData _playerData;

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
			if (state != PlayerState.AIMING)
			{
				StartCoroutine(ResetPlayerState(1.2f));
			}
		}

		IEnumerator ResetPlayerState(float time)
		{
			yield return new WaitForSeconds(time);
			_playerData.PlayerState = PlayerState.AIMING;
		}
	}
}