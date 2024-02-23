namespace ALS.BohlPon
{
	/// <summary>
	/// All the anticipated states for the player to be in within our game
	/// Aiming = when the player is prepping to fire the ball
	/// Pending = when the player has launched the ball
	/// Damaging = when the player is dealing damage
	/// Defending = when the player is being dealt damage
	/// Reloading = when the player is preparing the next shot
	/// </summary>
	public enum PlayerState
	{
		AIMING,
		PENDING,
		DAMAGING,
		DEFENDING,
		RELOADING,
	}
}