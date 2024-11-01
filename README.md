# BugSlayer
Jelly go kill bug (not programming bug but real-er bug)


2D 젤리 횡스크롤 플랫포머 액션 게임

주인공 젤리

# 1. 능력
- 죽지 않음. 산산조각 나더라도 조각들이 스스로 움직여서 다시 재생됨

- 몸에서 젤리를 고속으로 발사 가능(발사할때마다 최대체력 및 크기 감소, 쏘고 나서 바닥에 떨어진 젤리 먹으면 다시 늘어남)

- 자신의 몸을 압축했다가 특정 방향으로 자기 자신을 발사 가능

- 치석 먹고 특수능력 개화 가능


# 2. 먹을 수 있는 치석

## 치석
처음 튜토리얼 방에서 3개중 1개 선택. 그 이후 쉼터마다 선택지 제공(쉼터 선택지에는 하드모드 없음)
*하드모드 선택 시 쉼터에서의 선택지 사라짐.

원거리형 치석 - (원거리)원거리 공격 시 패널티 삭제, 최대체력 소량 감소, 원거리 공격력 증가.
(원거리형 치석이란게 있는가의 문제는 논하지 않는것이 좋다.)

근거리 치석 - (근거리)돌진 쿨타임 감소, 최대체력/방어력 소량 증가, 근거리 공격력 증가.
(근거리형 치석이란게 있는가의 문제는 논하지 않는것이 좋다.)

치석(?) - (하드모드)원거리 공격 근접 공격으로 변경, 최대체력 소량 감소, 돌진 데미지 삭제, 돌진 시 무적시간 감소, 돌진 거리 감소.
(이것이 진짜 치석인지는 모르겠으나 이것을 취한다면 돌이킬 수 없다.)


# 3. 장신구(패시브 추가)

## 보스 장신구
보스 처치 시 드랍. 3번째 보스로 나오는 경우에는 드랍 안함.

확정드랍
포도(?) - 최대체력 증가, 이동속도 증가
(포도처럼 생겼으나 포도는 아닌듯하다. 호기심에 입에 넣는 것만큼은 하지 말자.)

확률드랍
독 묻은 자석 - 공격에 독 데미지 추가
               (나선균의 보스전에서 발동)출혈 데미지 반감, 츨혈 게이지 증가량 감소
(냄새가 심하다. 가까이 하지 않는게 좋을듯하다. 이것이 많으면 아무도 당신과 대화하려 하지 않을것이다.)

탄성 없는 스프링 - 공격에 출혈 데미지 추가
                  (간균의 보스전에서 발동)스턴 유지시간 감소, 독 데미지 반감
(탄성이 없어져 실과 비슷해진 스프링 이었던 것이다. 탄성을 잃었어도 그 예리함은 여전하다. 오래 지니고 있으면 미약한 통증이 느껴진다.)

## 잡몹 장신구
잡몹 처치 시 확률적으로 드랍.

작은 구슬 - 이동속도 증가

*보스전에서도 확률적으로 드랍
자석조각 - 방어력 증가

*보스전에서도 확률적으로 드랍
뾰족한 실 - 공격력 증가


## 이벤트 장신구
맵 내 랜덤 인카운터로 나오는 이벤트 완료 시 확정적으로 드랍.

장신구 이름 - 장신구 효과(장신구 획득을 위한 이벤트 설명)

## 장신구
중간보스 처치 시 확정적으로 드랍.

장신구 이름 - 장신구 효과

# 4. 적대세력 세균

젤리들끼리 살고있던 젤리마을이 있었음.

어느날 갑자기 마을이 있는 숲 밖에서 젤리를 먹고사는 벌레들이 침공을 시작함.

다른 젤리들보다 유난히 단단한 젤리(주인공)가 벌레를 막기 위해 마을을 나옴.

마을 밖에 있는 벌레들이 마을을 찾기 전에 전부 내쫒아버리는게 목적

이였던것

## 보스 세균

1. 구균 - 둥글게 생김(귀엽진 않음), 작은 구균을 던지며 공격(기본 공격(아마도)), 가끔 플레이어를 향해 돌진(특수 공격)
   
2. 나선균 - 나뭇가지 처럼 생긴 스프링, 양손검으로 플레이어에게 접근하여 썬다(기본 공격), 가끔 몸에서 가시가 나와 플레이어를 찌름(특수 공격), 가끔 벽에 붙어서 에너지 충전 후 찌르기(특수 공격)
   
3. 간균 - 매미 자석 한쌍(2마리), 가끔 둘이 붙어서 충격파를 발생시킨다. 충격파에 맞으면 스턴(특수 공격)

   - 간균 - 매미 자석 한쪽(근거리), 돌진 박치기 하며 공격(기본 공격)

   - 간균 - 매미 자석 한쪽(원거리), 독가스 살포(기본 공격), 독가스는 사라지는 시간이 있음

## 잡몹 세균

작은 구균 - 플레이어를 향해 몸통 박치기 공격(기본 공격)

작은 나선균 - 실 같은 개체가 땅에서 머리만 내놓고 있다가 플레이어를 향해 돌진 공격(기본 공격)

작은 간균 - 작은 매미 자석 한쪽, 굴러다니다가 플레이어가 맞으면 도트딜, 슬로우 디버프(기본 공격)
