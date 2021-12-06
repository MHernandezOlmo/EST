using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FloatingJoystick : Joystick
{
	Vector3 initialPos;

	protected override void Start()
	{
		base.Start();
		initialPos = background.anchoredPosition;
	}

	public override void OnPointerDown(PointerEventData eventData)
	{
		background.anchoredPosition = ScreenPointToAnchoredPosition(eventData.position);
		base.OnPointerDown(eventData);
	}

	public override void OnPointerUp(PointerEventData eventData)
	{
		background.anchoredPosition = initialPos;
		base.OnPointerUp(eventData);
	}
}