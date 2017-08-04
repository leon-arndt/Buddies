//This class is auto-generated do not modify
namespace C
{
	public static class Scenes
	{
		public const string LOBBY = "Lobby";
		public const string IN_GAME = "InGame";
		public const string V_THIRD_PERSON_CONTROLLER_DEMO = "vThirdPersonController-Demo";

		public const int TOTAL_SCENES = 3;


		public static int nextSceneIndex()
		{
			if( UnityEngine.Application.loadedLevel + 1 == TOTAL_SCENES )
				return 0;
			return UnityEngine.Application.loadedLevel + 1;
		}
	}
}