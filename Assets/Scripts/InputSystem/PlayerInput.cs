using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

[DefaultExecutionOrder(-1)]
public class PlayerInput : MonoBehaviour
{
	public static Vector2 _Joystick { get; private set; }
	public static bool _JoystickPressed { get; private set; }
	public static bool _ContextButtonPressed { get; private set; }
	public static bool _ContextButtonDown { get; private set; }
	public static bool _ContextButtonUp { get; private set; }
	public static System.Action _OnContextButtonPressed, _OnContextButtonReleased;

	public Joystick touchJoystick;
	public Button contextButton;

	// Bind button's EventTrigger OnPointerDown to this method
	public void NotifyButtonClicked()
	{
		AudioEvents.playSoundWithName.Invoke(SFXManager.AudioCode.UIInstant);
		_OnContextButtonPressed?.Invoke();
		_ContextButtonDown = true;
		_ContextButtonPressed = true;
		StartCoroutine(crCancelInput());
	}

	public IEnumerator crCancelInput()
    {
		yield return null;
		_ContextButtonPressed = false;
	}

	// Bind button's EventTrigger OnPointerUp to this method
	public void NotifyButtonReleased()
	{
		_OnContextButtonReleased?.Invoke();
		_ContextButtonDown = false;
		_ContextButtonUp = true;
		_ContextButtonPressed = false;
	}

	// Bind joystick's EventTrigger OnPointerDown and OnPointerUp to these methods
	public void NotifyJoystickPressed() => _JoystickPressed = true;
	public void NotifyJoystickReleased() => _JoystickPressed = false;

	void Update()
	{
		_Joystick = Vector2.right * touchJoystick.Horizontal + Vector2.up * touchJoystick.Vertical;

		HandleGamepadInput();
	}

	void LateUpdate()
	{
		_ContextButtonDown = false;
		_ContextButtonUp = false;
	}

	void HandleGamepadInput()
	{
		touchJoystick.SetGamepadInput(Vector2.ClampMagnitude(Vector2.right * Input.GetAxis("Horizontal") + Vector2.up * Input.GetAxis("Vertical"), 1f));

		if (Input.GetButtonDown("Action") )
		{
			AudioEvents.playSoundWithName.Invoke(SFXManager.AudioCode.UIInstant);
			var pointer = new PointerEventData(EventSystem.current);
			ExecuteEvents.Execute(contextButton.gameObject, pointer, ExecuteEvents.pointerEnterHandler);
			ExecuteEvents.Execute(contextButton.gameObject, pointer, ExecuteEvents.pointerDownHandler);
		}

		if (Input.GetButtonUp("Action") )
		{
			var pointer = new PointerEventData(EventSystem.current);
			ExecuteEvents.Execute(contextButton.gameObject, pointer, ExecuteEvents.pointerUpHandler);
		}
	}


}
