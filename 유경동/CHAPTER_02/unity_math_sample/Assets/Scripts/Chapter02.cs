using System;
using UnityEngine;

public class Chapter02 : MonoBehaviour
{
	public float rotateSpeed = 1f;
	public float scrollSpeed = 200f;
	public Transform pivot;
	
	public SphericalCoordinates sphericalCoordinates;

	private void Start()
	{
		// 구면 좌표계를 초기화
		sphericalCoordinates = new SphericalCoordinates(transform.position);
		// 현재 위치 + 피벗 위치
		transform.position = sphericalCoordinates.ToCartesian + pivot.position;
	}

	private void Update()
	{
		float keyboardHorizontal, keyboardVertical, mouseHorizontal, mouseVertical, h, v;
		keyboardHorizontal = Input.GetAxis("Horizontal");
		keyboardVertical = Input.GetAxis("Vertical");
		
		bool anyMouseButton = Input.GetMouseButton(0) | Input.GetMouseButton(1) | Input.GetMouseButton(2);
		mouseHorizontal = anyMouseButton ? Input.GetAxis("Mouse X") : 0f;
		mouseVertical = anyMouseButton ? Input.GetAxis("Mouse Y") : 0f;
		
		h = Mathf.Abs(keyboardHorizontal) > Mathf.Abs(mouseHorizontal) ? keyboardHorizontal : mouseHorizontal;
		v = Mathf.Abs(keyboardVertical) > Mathf.Abs(mouseVertical) ? keyboardVertical : mouseVertical;
		// Epsilon = 0에 가까운 아주 작은 실수값을 반환한다.
		// 사실 == 이 아니면 0과 비교해도 괜찮을 것 같다.
		if (Mathf.Abs(h) > 0 || Mathf.Abs(v) > 0) 
		// if (Mathf.Abs(h) > Mathf.Epsilon || Mathf.Abs(v) > Mathf.Epsilon) 
		{
			// 해당 방향으로 회전한 값을 적용
			transform.position
				= sphericalCoordinates.Rotate(
					h * rotateSpeed * Time.deltaTime, 
					v * rotateSpeed * Time.deltaTime).ToCartesian + pivot.position;
		}

		// 스크롤 바를 조작하여 r값(객체와 카메라간 거리)을 조정
		float sw = -Input.GetAxis("Mouse ScrollWheel");
		if (Mathf.Abs(sw) > Mathf.Epsilon)
		{
			transform.position = 
				sphericalCoordinates.TranslateRadius(
					sw * Time.deltaTime * scrollSpeed).ToCartesian + pivot.position;
		}

		// 이동을 마치면 대상을 향하게 방향 전환
		transform.LookAt(pivot.position);
		
	}
}


/// <summary>
/// 구면 좌표계로 x, y, z가 아닌 반지름, 방위각, 양각으로 객체의 좌표를 표현한다.
/// </summary>
[Serializable]
public class SphericalCoordinates
{
	// 반지름, 방위각, 양각(고도)
	private float _radius;
	private float _azimuth; 
	private float _elevation;
	
	public float _minRadius = 3f;
	public float _maxRadius = 20f;

	public float minAzimuth = 0f;
	private float _minAzimuth;

	public float maxAzimuth = 360f;
	private float _maxAzimuth;

	public float minElevation = 0f;
	private float _minElevation;

	public float maxElevation = 90f;
	private float _maxElevation;
	
	public float radius
	{
		get { return _radius; }
		private set {
			_radius = Mathf.Clamp(value, _minRadius, _maxRadius);
		}
	}
	
	public float azimuth
	{
		get { return _azimuth; }
		private set
		{
			// 나머지 연산 한값을 반환하는 것과 같은 기능
			// value가 lenght보다 크면 나머지 연산을 통해 0부터 시작하게 함
			_azimuth = Mathf.Repeat(value, _maxAzimuth - _minAzimuth);
		}
	}
	
	public float elevation
	{
		get { return _elevation; }
		private set
		{
			_elevation = Mathf.Clamp(value, _minElevation, _maxElevation);
		}
	}
	public SphericalCoordinates(){}
	
	
	// 직교좌표를 인자로 받아 구면 좌료로 변환할 수 있다.
	public SphericalCoordinates(Vector3 cartesianCoordinates)
	{
		_minRadius = 0f;
		_maxRadius = float.MaxValue;
		
		// 라디안으로 변환
		_minAzimuth = Mathf.Deg2Rad * minAzimuth;
		_maxAzimuth = Mathf.Deg2Rad * maxAzimuth;
		
		_minElevation = Mathf.Deg2Rad * minElevation;
		_maxElevation = Mathf.Deg2Rad * maxElevation;
	
		// 해당 정점까지의 거리 (r)
		radius = cartesianCoordinates.magnitude;
		
		// 아크탄젠트를 이용하여 방위각을 구함
		// 방위각은 x, z축을 이용하여 구할 수 있다.
		// 직교좌표축의 x좌표가 밑변, z좌표가 높이이므로 아크탄젠트를 이용하여 각도를 구할수 있다.
		azimuth = Mathf.Atan2(cartesianCoordinates.z, cartesianCoordinates.x);

		// 아크사인을 이용하여 양각을 구함
		// 양각은 x || z, y축을 이용하여 구할 수 있다.
		// 직교좌표 높이 y, 빗변 radius로 아크사인을 이용하여 각도를 구할 수 있다.
		elevation = Mathf.Asin(cartesianCoordinates.y / radius);
		// atan2(y, √(x^2 + z^2))로도 가능한가?
		
	}
	
	
	public Vector3 ToCartesian
	{
		get
		{
			// t = x, z사이의 빗변 빗변
			float t = radius * Mathf.Cos(elevation);
			// x = t * cos(방위각)
			// y = 반지름 * sin(양각)
			// z = t * sin(방위각)
			return new Vector3(
				/* x */ t * Mathf.Cos(azimuth), 
				/* y */ radius * Mathf.Sin(elevation), 
				/* z */ t * Mathf.Sin(azimuth));
		}
	}
	
	// 해당 방향으로 회전
	public SphericalCoordinates Rotate(float newAzimuth, float newElevation)
	{
		azimuth += newAzimuth;
		elevation += newElevation;
		return this;
	}
	
	// 반지름을 이동
	public SphericalCoordinates TranslateRadius(float x)
	{
		radius += x;
		return this;
	}
}

