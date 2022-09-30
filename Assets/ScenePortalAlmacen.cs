using UnityEngine;



[RequireComponent(typeof(BoxCollider))]
public class ScenePortalAlmacen : MonoBehaviour
{
	public SceneReference targetScene;
	public bool canComeBack = true;

	public Vector3 arrivingAutopilotOffset = Vector3.back;
	public Vector3 leavingAutopilotOffset = Vector3.forward;

	public Vector3 ArrivingAutopilotPoint => transform.TransformPointUnscaledUnrotated(arrivingAutopilotOffset);
	public Vector3 LeavingAutopilotPoint => transform.TransformPointUnscaledUnrotated(leavingAutopilotOffset);


	public SpawnInfo GetSpawnInfo()
	{
		var info = new SpawnInfo();
		info.spawnAt = LeavingAutopilotPoint;
		info.runTo = ArrivingAutopilotPoint;
		return info;
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player") &&
			!LevelRecentlyLoaded() &&
			!other.GetComponent<MovementController>().autopilot.HasValue)
		{
			if (FindObjectOfType<PlayerController>() != null)
			{
				FindObjectOfType<PlayerController>().OnExit();

			}
            //other.GetComponent<MovementController>().autopilot = LeavingAutopilotPoint;

            if (GameProgressController.PicDuMidiFindFiltersAdvice)
            {
				GameEvents.LoadScene.Invoke(targetScene.SceneName);
            }
            else
			{
				GameEvents.ShowScreenText.Invoke("Reach the CLIMSO coronograph first!");

			}
			//LevelLoader.LoadLevel(targetScene); // TO DO: make this not automatic
			//TO DO --> CARGAR ESCENA

		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.CompareTag("Player") && !canComeBack)
		{
			GetComponent<BoxCollider>().isTrigger = false;
		}
	}

	bool LevelRecentlyLoaded() => CurrentSceneManager._elapsedSceneTime <= 1f;
	void OnDrawGizmos()
	{
		Gizmos.color = Color.green.With(a: 0.5f);
		Gizmos.matrix = transform.localToWorldMatrix;
		Gizmos.DrawCube(Vector3.zero, GetComponent<BoxCollider>().size);
		Gizmos.DrawWireCube(Vector3.zero, GetComponent<BoxCollider>().size);
	}

	void OnDrawGizmosSelected()
	{
		Gizmos.matrix = Matrix4x4.TRS(transform.position, Quaternion.identity, Vector3.one);
		Vector3 cubeSize = new Vector3(0.5f, 0.1f, 0.5f);

		Gizmos.color = Color.blue.With(a: 0.5f);
		Gizmos.DrawCube(arrivingAutopilotOffset, cubeSize);

		Gizmos.color = Color.red.With(a: 0.5f);
		Gizmos.DrawCube(leavingAutopilotOffset, cubeSize);
	}


	void SetThisPortalAsLevelDefault()
	{
		//		Level level = FindObjectOfType<Level>();
		//		if (level)
		//		{
		//			level.defaultScenePortal = this;
		//#if UNITY_EDITOR
		//			UnityEditor.EditorGUIUtility.PingObject(level);
		//#endif
		//		}
		//		else
		//		{
		//			Debug.LogWarning("@LEVEL not found, create it first!");
		//		}
	}

#if UNITY_EDITOR
	[UnityEditor.MenuItem("GameObject/Create Scene Portal", false, 0)]
	static ScenePortal CreateScenePortalObjEditor()
	{
		ScenePortal portalPrefab = Resources.Load<ScenePortal>("ScenePortal");
		GameObject newPortalObj = UnityEditor.PrefabUtility.InstantiatePrefab(portalPrefab.gameObject) as GameObject;

		Camera sceneCamera = UnityEditor.SceneView.GetAllSceneCameras()[0];
		newPortalObj.transform.position = sceneCamera.transform.position + sceneCamera.transform.forward * 2f;

		UnityEditor.Undo.RegisterCreatedObjectUndo(newPortalObj, "Create " + newPortalObj.name);
		UnityEditor.EditorGUIUtility.PingObject(newPortalObj);
		return newPortalObj.GetComponent<ScenePortal>();
	}
#endif

}