using System;
using System.Collections.Generic;
using System.Text;

namespace gravity_game
{
	public interface IGameSettings
	{
		int Gravity { get; set; }
		int GravityValue { get; set; }
		int ObstacleSpeed { get; set; }
		int CoinSpeed { get; set; }
		int CoinScore { get; set; }
		int CoinHighScore { get; set; }
		int Score { get; set; }
		int HighScore { get; set; }
	}
}
