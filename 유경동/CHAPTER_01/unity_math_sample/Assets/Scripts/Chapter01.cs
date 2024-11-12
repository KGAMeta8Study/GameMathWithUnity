using UnityEngine;
using UnityEngine.EventSystems;

public class Chapter01 : MonoBehaviour {

	private GameObject capsule;

	private float targetAngle = 0f;
	public float capsuleRotationSpeed = 4f;

	private GameObject sphere;
	private float buttonDownTime;

	public float sphereMagnitudeX = 2.0f;
	public float sphereMagnitudeY = 3.0f;
	public float sphereFrequency = 1.0f;

	private void Start()
	{
		capsule = GameObject.Find("Capsule");
	}

	private void Update() 
	{
		if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
		{
			targetAngle = GetRotationAngleByTargetPosition(Input.mousePosition);
			if (sphere != null) 
			{
				Destroy(sphere);
				sphere = null;
			}
			sphere = SpawnSphereAt(Input.mousePosition);
			buttonDownTime = Time.time;
		}
		capsule.transform.eulerAngles = new Vector3(0, 0, Mathf.LerpAngle(capsule.transform.eulerAngles.z, targetAngle, Time.deltaTime * capsuleRotationSpeed));

		if (sphere != null) 
		{
			sphere.transform.position = new Vector3(
				sphere.transform.position.x + (capsule.transform.position.x - sphere.transform.position.x) * Time.deltaTime * sphereMagnitudeX,
				// PI * 2를 곱해주면 sin 함수의 주기가 1이 된다.
				// Update 함수가 호출될 때마다 Time.time은 1초에 1씩 증가하므로, PI * 2곱하면 1초에 딱 360도가 된다. 이는 그 중간 프레임에 주기를 표현하기에 적합하다.
				Mathf.Abs(Mathf.Sin ((Time.time - buttonDownTime) * (Mathf.PI * 2) * sphereFrequency) * sphereMagnitudeY),
				0);
		}
	}
	
	//Atan 90 -  abs(bx - ax) / (a - b)

	float GetRotationAngleByTargetPosition(Vector3 mousePosition)
	{
		Vector3 selfScreenPoint = Camera.main.WorldToScreenPoint(capsule.transform.position);
		Vector3 diff = mousePosition - selfScreenPoint;
		
		float angle = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
		float finalAngle = angle - 90f;
		return finalAngle;
	}

	GameObject SpawnSphereAt(Vector3 mousePosition)
	{
		GameObject sp = GameObject.CreatePrimitive(PrimitiveType.Sphere);
		Vector3 selfScreenPoint = Camera.main.WorldToScreenPoint(capsule.transform.position);
		Vector3 position = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, selfScreenPoint.z));
		sp.transform.position = new Vector3(position.x, position.y, 0);
		return sp;
	}
}

