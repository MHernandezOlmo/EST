using UnityEngine;

public static class FloatExt
{
	public static Vector3 Up(this float self) => self * Vector3.up;
	public static Vector3 Down(this float self) => self * Vector3.down;
	public static Vector3 Right(this float self) => self * Vector3.right;
	public static Vector3 Left(this float self) => self * Vector3.left;
	public static Vector3 Forward(this float self) => self * Vector3.forward;
	public static Vector3 Back(this float self) => self * Vector3.back;
}