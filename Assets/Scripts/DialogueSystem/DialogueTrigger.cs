using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider))]
//[RequireComponent(typeof(Dialogue))]

public class DialogueTrigger : MonoBehaviour
{
	[SerializeField] UnityEvent _finishEvent;
	MovementController player;
    [SerializeField] bool _playOnce;
	[SerializeField] CameraPriorizer _cPrio;

    void Start()
	{
		//GetComponent<Dialogue>().onDialogueFinished.AddListener(HandleDialogueFinished);
	}

	void OnTriggerEnter(Collider other)
	{
        
		if (other.GetComponent<MovementController>())
		{
            //player = other.GetComponent<MovementController>();
            //player.DisableMovement();
            //GetComponent<Dialogue>().StartDialogue();
            //this.gameObject.SetActive(false);
            if (_playOnce)
            {
                GetComponent<BoxCollider>().enabled = false;
				if(_cPrio != null)
                {
					_cPrio.PriorizeCamera();
                }
            }
            triggerDialogueEvent(true);
        }
	}

	public void triggerDialogueEvent(bool onDialogue)
	{
        FindObjectOfType<DialogController>().SetCurrentDialogue(GetComponent<TestDialogue>());
        GameEvents.eDialogue.Invoke(onDialogue);
	}
	public void triggerDialogueEvent()
	{
		FindObjectOfType<DialogController>().SetCurrentDialogue(GetComponent<TestDialogue>());
		GameEvents.eDialogue.Invoke(true);
	}

	public void HandleDialogueFinished()
	{
		if (_cPrio != null)
		{
			_cPrio.StopToPriorize();
		}
		_finishEvent.Invoke();
	}

	public void FinishEvent()
    {
		_finishEvent.Invoke();
	}

	void OnDrawGizmos()
	{
		Gizmos.color = new Vector4(0f, 0.2f, 0.8f, 0.5f);
        Gizmos.matrix = transform.localToWorldMatrix;
        Gizmos.DrawCube(Vector3.zero, GetComponent<BoxCollider>().size);
        Gizmos.DrawWireCube(Vector3.zero, GetComponent<BoxCollider>().size);
    }


#if UNITY_EDITOR
	[UnityEditor.MenuItem("GameObject/Create Dialogue Trigger", false, 0)]
	static DialogueTrigger CreateSceneDialogueObjEditor()
	{
		if (GameObject.FindGameObjectsWithTag("Enemy").Length > 0)
		{
			Debug.LogError("[EST] Hay enemigos en la escena, las escenas con dialogos y combates deben estar separadas");
			return null;
		}
		DialogueTrigger dialoguePrefab = Resources.Load<DialogueTrigger>("DialogueTrigger");
		GameObject newdialogueObj = UnityEditor.PrefabUtility.InstantiatePrefab(dialoguePrefab.gameObject) as GameObject;

		Camera sceneCamera = UnityEditor.SceneView.GetAllSceneCameras()[0];
		newdialogueObj.transform.position = sceneCamera.transform.position + sceneCamera.transform.forward * 2f;

		UnityEditor.Undo.RegisterCreatedObjectUndo(newdialogueObj, "Create " + newdialogueObj.name);
		UnityEditor.EditorGUIUtility.PingObject(newdialogueObj);
		return newdialogueObj.GetComponent<DialogueTrigger>();
	}
#endif
}
