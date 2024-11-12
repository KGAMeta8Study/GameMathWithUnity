# CHAPTER 01 : 삼각 함수

## 1.1 삼각형

삼각형은 세 정점, 세 변으로 이루어져 있다.
삼각형의 세 변 중 두 개의 변이 이루는 각을 **내각** 이라고한다.
삼각형의 세 개의 내각의 합은 항상 180도이다. 그리고 삼각형은 항상 평면 위에 존재한다(2차원).  
반면 정점이 네 개일 때는 평면상에 없고, 3차원 공간에밖에 표현할 수 없다.  
삼각형은 평면을 구할 수 있는 최소 단위로 평면 위에서 가장 단순하고 안정된 도형이기 때문에, 삼각형이 3D도형이나 표면을 처리할때 가장 작은 단위로 사용된다.

## 1.2 직삼각형

삼각함수에서 주로 다루는 삼각형은 세 개의 정점 부분의 내각 중 하나가 직각(90도)을 이루는 **직각삼각형**이다.
<img src="https://github.com/user-attachments/assets/8608f035-8a38-48a9-ad28-ba8d3b198a83" width="400"/>

이러한 직각삼각형에서 세변의 길이와 각 변을 이루는 내각의 각도 θ(세타, seta) 사이에 존재하는 관계를 이용해서 두 변의 길이와 θ를 구할 수 있다.

## 1.3 피타고라스의 정리

피타고라스의 정리는 빗변의 길이 z, 밑변의 길이 x, 높이의 길이 y로 뒀을때 다음과 같은 식이 성립한다.
z² = x² + y²

## 1.4 사인, 코사인, 탄젠트

직각삼각형에서 **두 변의 길이의 비율(삼각비)**은 **각도 θ**에 따라 변한다. 따라서, 각도 θ를 입력값으로 받아 출력값이 변화하는 함수 형태로, 삼각형의 변 사이의 관계를 나타낼 수 있다.
삼각형의 세 변 중 두 변의 길이, 혹은 한 변의 길이와 각도 θ를 알면, 삼각비를 이용해 나머지 변의 길이나 각도를 계산할 수 있다.  
<img src="https://github.com/user-attachments/assets/1b046536-d742-4c81-874e-25786607d02b" width="400"/>

### sin θ

sinθ 는 각도가 θ일 때 빗변과 높이의 비율을 나타낸다.  
즉, 빗변의 길이와 θ의 각도를 알고 있을 때 빗변의 길이에 sinθ를 곱하면 높이의 길이를 구할 수 있다.

c = 빗변  
h = 높이  
이라고 정의했을 때 sinθ를 적용하여 구할 수 있는 식은 다음과 같다.

<img width="110" alt="스크린샷 2024-10-21 20 44 13" src="https://github.com/user-attachments/assets/b1c97938-474b-4505-906a-6428f4406afc">
<img width="123" alt="스크린샷 2024-10-21 20 44 27" src="https://github.com/user-attachments/assets/9ce90fbb-9438-4a12-97d5-b4472b1dbfda">

### cos θ

cosθ 는 각도가 θ일 때 빗변과 밑변의 비율을 나타낸다.

c = 빗변
b = 밑변
이라고 정의했을 때 cosθ를 적용하여 구할 수 있는 식은 다음과 같다.

<img width="123" alt="스크린샷 2024-10-22 18 53 51" src="https://github.com/user-attachments/assets/94b1f0b4-6dbc-4424-bb05-b2e7d90001d1">
<img width="123" alt="스크린샷 2024-10-22 18 54 02" src="https://github.com/user-attachments/assets/09b01390-cf26-4500-aed3-fa014cbba3a8">

### tan θ

tanθ 는 각도가 θ일 때 밑변과 높이의 비율을 나타낸다.

h = 높이
b = 밑변
이라고 정의했을 때 tanθ를 적용하여 구할 수 있는 식은 다음과 같다.

<img width="123" alt="스크린샷 2024-10-22 19 07 41" src="https://github.com/user-attachments/assets/a0cdc113-2eb7-431a-b7f5-17821e0474fd">
<img width="123" alt="스크린샷 2024-10-22 19 07 36" src="https://github.com/user-attachments/assets/b67bedfd-b4a9-48f3-b727-b49aeb580847">

### 역삼각함수

또한, 내각 θ를 매개변수로 받아 각 변끼리의 비율을 반환하는 사인, 코사인, 탄젠트에 대응해 그 역함수로서 각 변끼리의 비율을 매개변수로 하여 내각 θ을 구하는 일련의 함수도 있다.  
아크사인, 아크코사인, 아크탄젠트를 사용하면 각각에 대응하는 각도 θ을 산출할 수 있다.  
θ = arcsin(sinθ);  
θ = arccos(cosθ);  
θ = arctan(tanθ);
이는 삼각형의 세 변 중 두변의 길이를 알 때 이 역함수들을 적용하여 θ의 각도를 구할 수 있다는 얘기이다.

### 삼각함수 문제풀이

https://ko.khanacademy.org/math/geometry/hs-geo-trig/hs-geo-solve-for-an-angle/a/inverse-trig-functions-intro

## 1.5 삼각함수의 주기성

위의 삼각함수는 직각삼각형을 염두에둔 개념이기에 θ의 크기는가 0 < θ < 90으로 한정된다.  
이번에는 직각삼각형을 포함한 원을 통해 삼각함수를 표현하는 방법을 사용한다.

### 단위원

<img alt="스크린샷 2024-10-22 19 07 36" src="https://github.com/user-attachments/assets/83734f1b-9a34-4f6f-b2a1-880961a0834d">

이 그림은 반지름의 길이가 1인 원 **단위원**(unit circle)이라고 한다. 빗변의 길이가 1이기 때문에 이를 통해 B의 x, y값을 구할 수 있다.  
x = cosθ
y = sinθ
이다.  
빗변이 1인 삼각형의 밑변은 cosθ x 빗변인데 빗변은 1이므로 밑변은 cosθ가 된다.

빗변이 1인 삼각형의 높이는 sinθ x 빗변인데 빗변은 1이므로 높이는 sinθ이 된다.

### 결론

단위원 일 때 단위원 원둘레 위의 점의 위치 B = {cosθ, sinθ}로 구할 수 있다.

### 코사인 법칙

### 라디안

180도 = π(라디안)
C = 2πr

상수 π를 사용하는 한 도수법으로 표현하기 보다 라디안으로 표현하는 쪽이 간결하므로 각도를 라디안으로 표현하는 것이 일반적이다.

<img alt="스크린샷 2024-10-22 19 07 36" src="https://github.com/user-attachments/assets/c9db04f0-a157-4947-9e37-a102db79de7b">
위 그림은 단위원일때 삼각함수의 실제 값이다.

### 1.5.5 덧셈정리

다음과 같은 그림이 있을 때 P'의 좌표는 cos(α + β), sin(α + β)이다.

<img alt="스크린샷 2024-10-22 19 07 36" src="https://github.com/user-attachments/assets/f0d7ebbe-93e8-474a-9c93-edb007ef8675">

cos(α + β), sin(α + β)를 구할 수 있는 **덧셈정리**도 존재한다.

sin(α ± β) = sin(α) cos(β) ± cos(α) sin(β)
cos(α ± β) = cos(α) cos(β) ∓(부호가 반대) sin(α) sin(β)

이 식은 임의의 좌표 (x, y)에 대한 원점 중심의 회전 알고리즘으로 사용 가능하다.  
x = sin(α)로 치환하고
y = cos(β)로 치환했을때 {x, y}에서 β만큼 회전하면 다음과 같다.  
x cos(β) - y sin(β), cos(β) + x sin(β)

### 사인파, 코사인파

원의 최대 각도는 360도 뿐이다. 360도 보다 큰 각도로 회전시킨 삼각함수의 값은 주기적으로 같은 값을 취한다. 라디안을 가로축으로 했을 때 사인 값을 세로축으로 하는 그래프를 만든다. 2π를 1주기로 해서 0 -> 1 -> 0 -> 1이러한 변동이 반복된다.

상수 P에 대해서 f(x + P) = f(x)가 성립하는 함수를 **주기함수**라고 부르지만, sin에 대해서는 P = 2π이다. 즉 다음과 같다.  
f(x + P) = f(x)
sin(x + 2π) = sin(x)
2π = 360도 이기때문에 360도 주기로 값은 같다.  
코사인파는 x 축 방향으로 - π/2 이동시키면 코사인파이다.
<img alt="스크린샷 2024-10-22 19 07 36" src="https://github.com/user-attachments/assets/3fdf99ab-813a-49fe-a0b9-9ddd02c04765">

사인파와 코사인파의 기본주기는 2π이지만, 매개변수 x의 값에 따라 주기가 바뀐다.  
<img alt="스크린샷 2024-10-22 19 07 36" src="https://github.com/user-attachments/assets/27a5340c-aab5-4bdb-b0e4-65ee80c4c9ca">

다음은 sin(θ)의 절대값(magnitude)를 사옹하여 갑싱 음수가 되는 부분의 부호를 양수로 만든 그래프이다.  
<img alt="스크린샷 2024-10-22 19 07 36" src="https://github.com/user-attachments/assets/bad880bc-800f-4812-857d-c74479c387d9">

참고자료
https://angeloyeo.github.io/2022/01/04/sinusoids.html#google_vignette

## 1.6 유니티 예제

`Mathf.LerpAngle` 각도를 보간하는 함수로 360도 주기로 자동으로 변환해준다. Mathf.LerpAngle(0, 362, 0.5)의 경우 181이 아니라, 1이 나온다.
`EventSystem.current.IsPointerOverGameObject ` UI에 마우스 포인터가 있는지 체크

`Mathf.Atan2(float y, float x)` 라디안이 아닌 y, x좌표를 인자로 넘겨주면 각도를 반환한다. 반환값은 라디안이다.
도(degree)수가 필요하다면 `Mathf.Rad2Deg`를 곱해주면 degree로 변환된다.

```
sphere.transform.position = new Vector3(
	sphere.transform.position.x + (capsule.transform.position.x - sphere.transform.position.x) * Time.deltaTime * sphereMagnitudeX,
	Mathf.Abs(Mathf.Sin ((Time.time - buttonDownTime) * (Mathf.PI * 2) * sphereFrequency) * sphereMagnitudeY),
	0);
```

sphere의 위치를 구하는 식이다. x값은 capsule을 향해 움직이고 있고,
y값은 |sin| 값으로 호를 그리면서 이동한다.  
여기서 Mathf.PI \* 2를 곱해주는 이유는 사인 함수의 주기를 조정하여 초당 한 번의 진동을 완성하기 위해서이다. 기본적으로 Mathf.Sin 함수는 입력 값이 0에서 2π(약 6.28) 라디안일 때 하나의 주기가 완성된다.

따라서 Time.time은 초당 1씩 증가하므로, 초당 완전한 사인파 주기를 만들기 위해 Mathf.PI \* 2를 곱해준다.
