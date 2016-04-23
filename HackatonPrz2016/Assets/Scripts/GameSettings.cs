using UnityEngine;
using System.Collections;

public static class GameSettings  {


	public struct PlayerPreferences
	{
		public Color color;
		public string name;
		public KeyBindings keyBindings;
	}


	public struct KeyBindings
	{
		public string up, down;
		public string left, right;
		public string fastAttack, strongAttack, dash;
	}
}
