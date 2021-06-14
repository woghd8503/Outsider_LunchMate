    using System;
using System.Collections.Generic;
using System.Text;

namespace LunchMate
{
    interface IGameBox
    {
        public abstract void ShowMenu();      // 메뉴 출력
        public abstract void ExplainGame();   // 게임 설명
        public abstract void PlayGame();      // 게임 
        public abstract void InputGame();     // 입력 값 받기
        public abstract object SendPacket();    // 서버로 보낼 패켓값 클라이언트로 보냄
    }
}
