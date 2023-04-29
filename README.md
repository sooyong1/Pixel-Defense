# Pixel-Defense

*Asset폴더의 0.GameManager, 1.Script 폴더안에 있는 코드들을 직접 구현하였습니다. 1.Script/Track 폴더안에 있는 ReviseCartCode는 시네머신에서 가져와 제 게임에 맞게 수정한 코드입니다.

**게임 소개** : 용병들을 맵에 배치하여 몰려드는 몬스터들을 막아내는 게임입니다. 흰색 보석을 사용하여 용병을 고용하거나 세공을하여 색깔 보석을 획득하여 용병을 강화시킬 수 있습니다.
용병 고용과 색깔 보석 획득은 랜덤이므로 주어지는 상황에 맞게 용병들을 배치하고 강화하여 몬스터들을 막아내야합니다. 각 용병들과 몬스터들 사이에는 상성이 있기 때문에 적절한 조합과
배치가 중요합니다.

---
### 주요사용 기술
**오브젝트 풀링** : 많은 투사체가 발생하므로 오브젝트 풀링 기법을 사용하여 오브젝트의 생성,제거에 걸리는 시간을 최소화하고 데이터 누수를 방지하였습니다.

**전략 패턴** : 용병(타워)들은 Tower 클래스를 상속받으며 각 세부 타워 스크립트는 가상함수를 통해 공격 패턴, 업그레이드 내용 등을 가상함수를 통해 재정의 해주었습니다. 

**콜백함수** : 각 용병들은 자신의 강화 내용들을 함수에 구현되어있습니다. 현재 강화 레벨과 타입에 따라 다음 강화 내용을 담은 함수를 대리자에 넣어두었고 UI버튼을 눌러 강화를 할 때 
           해당 함수가 실행되도록 구현하였습니다.

**시네머신 스크립트 수정** : 유니티에서 제공해주는 시네머신 스크립트를 이 게임에 맞게 수정하여 몬스터가 이동할 트랙을 구현하였습니다.
