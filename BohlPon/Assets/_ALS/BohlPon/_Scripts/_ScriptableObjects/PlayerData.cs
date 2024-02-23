using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ALS.BohlPon
{
	[CreateAssetMenu(fileName = "Player Data", menuName = "Player/PlayerData")]
	public class PlayerData : ScriptableObject
	{
		#region Delegates
		//Declaring
		public delegate void PlayerStateChanged(PlayerState state); //Channel 
																	//Creating New Channel Instance
		public PlayerStateChanged OnPlayerStateChanged;
		#endregion

		[SerializeField] private PlayerState _playerState;
		public PlayerState PlayerState
		{
			get => _playerState;
			set { _playerState = value; OnPlayerStateChanged?.Invoke(value); }
		}
	}
}