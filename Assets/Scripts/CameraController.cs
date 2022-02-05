using UnityEngine;

public class CameraController : MonoBehaviour
{
	public float mouseSens = 150.0f;
	public Transform player;
	public float yRotation;

	private void Update()
	{
		var mouseX = Input.GetAxis("Mouse X") * mouseSens * Time.deltaTime;
		yRotation = mouseX;
		var target = player.position;
		transform.RotateAround(target, Vector3.up, yRotation);
	}
}
