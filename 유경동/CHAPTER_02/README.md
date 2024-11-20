
# CHAPTER 02 : 좌표계
좌표계는 물체의 위치를 특정하기위 체계이다.

## 2.1 직교좌표계
직교좌표계는 원점(0, 0, 0)에서 직각으로 교차하는 x, y, z축을 기준으로 좌표를 나타내는 방식이다.

### 왼손 좌표계  
오른손 좌표계유니티가 채용한 z방향의 좌표계를 가리켜 왼손 좌표계라고 한다.OpenGL, WebGL은 오른손 좌표계를 사용한다.
왼손 좌표계와 오른손 좌표계는 z축의 방향을 뒤집으면 서로 변환이 가능하다.

### 로컬 좌표계와 월드 좌표계
로컬 좌표계는 물체 자신의 좌표계를 말하며, 월드 좌표계는 전체 공간의 좌표계를 말한다.

유니티의 Inspecter창에서 Transform 컴포넌트의 Position, Rotation, Scale은 로컬 좌표계를 기준으로 표시된다.  
자기 자신의 좌표계를 기준으로 이동, 회전, 크기를 조정하는 것이 로컬 좌표계이다.  
이 로컬 좌표계로 다른 물체와 상호 관계를 파악할 수 없다. 이때 사용하는 것이 월드 좌표계이다.  
Transform 컴포넌트의 position은 월드 좌표계를 기준으로 표시된다.   
로컬 좌표계은 localPosition으로 확인 가능하다.   


### 스크린 좌표
유니티에는 스크린 공간을 위한 좌표계인 스크린 좌표계가 있다.   
스크린 좌표계는 화면 좌하단을 원점(0,0)을 기준으로 해상도에 따라 픽셀 위치를 단위로하는 2D 직교좌표계다.  

WorldToScreenPoint()는 월드 좌표를 스크린 좌표로 변환한다.  
사용자의 마우스 입력은 스크린 좌표계로 들어오기 때문에 스크린 좌표계를 사용해 마우스 입력을 처리해야 한다.  

유니티에는 스크린 좌표를 정규화(nomalize)한 뷰포트 좌표가 있다.  
뷰표트 좌표에서는 화면 해상도에 관계없이 좌하단을 (0,0), 우상단을 (1,1)로 표시한다.  

## 2.2 극좌표계

### 2D 극 좌표계
x, y, z로 표현하던 직교좌표계와는 다르게 극 좌표계는 반지름과 각도로 표현한다.  
직교 좌표계 : (x,y)
극 좌표계 : (r, θ)

<img width="400" src="https://github.com/user-attachments/assets/d424026f-245f-4ee2-9ba3-6632cede3efa"/>

중심인 극이라는 기준점을 기준으로 원점에서 가로 방햔 x축으로 뻗어가는 극축을 기준으로 한다.  
(r, θ) = (r cosθ, r sinθ)로도 치환이 가능하다.  

### 3D 극 좌표계 : 구면 좌표계
구면좌표계(3D 극 좌표계)는 반지름, 방위각, 고도로 표현한다.  
<img width="400" src="https://github.com/user-attachments/assets/7f3e4b96-828f-4e89-8f25-dbf67413b930"/>

3D 극 좌표계도 2D 극 좌표계에 축을 하나 더 했을 뿐이므로, 삼각함수를 사용해서 직교좌표계로 변환이 가능하다.  
(r, θ, φ) = (r sinθ cosφ, r sinθ sinφ, r cosθ)로 변환 가능하다.  

구면 좌표계는 중심을 기준으로 각도와 반지름을 통해 객체를 위치시키기 때문에, 회전 중심을 기준으로 하는 이동이나 특정 궤도를 따르는 객체에 유리하다.  
예를 들어, 중심을 돌면서 일정한 반지름을 유지하거나, 카메라가 특정 지점을 따라 회전하는 상황에서 효과적이다.  

## 2.3 유니티 예제
유니티 예제는는 카메라가 특정 기준점(pivot)을 중심으로 회전하고 확대/축소할 수 있도록 구현한다.  
여기서 카메라의 움직임을 직교좌표계 대신 구면 좌표계(극좌표계 확장)를 사용하여, 중심점에서의 반지름 거리와 각도(방위각, 양각)로 위치를 계산한다.  

<img width="400" src="https://github.com/user-attachments/assets/aa0b45b4-a84b-4d00-9872-1e33a3383f51"/>


다음은 직교좌표계(유니티의 position)를 구면 좌표계로 변환하는 코드이다.  
```c#
Vector3 cartesianCoordinates;
radius = cartesianCoordinates.magnitude;
azimuth = Mathf.Atan2(cartesianCoordinates.z, cartesianCoordinates.x);
elevation = Mathf.Asin(cartesianCoordinates.y / radius);
```
cartesianCoordinates는 카메라의 position(직교좌표계)이다.  
이를 극좌표계의 반지름, 방위각, 고도로 변환한 것이다.  
radius는 반지름으로 magnitude으로 해당 벡터의 크기로 구했다.  
azimuth는 방위각으로 Atan2()함수를 사용해 z축과 x축 사이의 각도를 구했다.  
elevation은 고도로 Asin()함수를 사용해 y축과 반지름 사이의 각도를 구했다.  

다음은 구면 좌표계를 직교좌표계로 변환하는 코드이다.
```c#
public Vector3 ToCartesian
{
    get
    {
        float t = radius * Mathf.Cos(elevation);

        return new Vector3(
            /* x */ t * Mathf.Cos(azimuth), 
            /* y */ radius * Mathf.Sin(elevation), 
            /* z */ t * Mathf.Sin(azimuth));
    }
}
```

<img width="400" src="https://github.com/user-attachments/assets/71b28a55-79da-4191-9093-61314e3a957f"/>

t = x, z사이의 빗변의 길이로, x, z를 구하기 위한 중간 계산값이다.  
x = t * cos(방위각)  
y = 반지름 * sin(양각)  
z = t * sin(방위각)  