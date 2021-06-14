using System;
using System.Collections.Generic;
using System.Text;

namespace LunchMate_Server
{
    class JudgeGame
    {
        string result { get; set; }

        public string _1_RockScissorPaper(int player, int player1, int player2)
        {
            result = "아무것도 없지롱";
            if ((player == player1 && player == player2) || (player != player1 && player != player2 && player1 != player2))
            {
                result = "[결과] 승부를 가릴 수없음... 비김    [다시 입력하시오]";
            }
            else
            {
                if ((player + 1) % 3 == player2 && player == player1) // 3 3 1
                {
                    result = "[결과] 승자: [3p] 패자: [1p와 2p] 밥값내세요!!";
                }
                else if ((player + 1) % 3 == player1 && player == player2 ) // 3 1 3
                {
                    result = "[결과] 승자: [2p] 패자: [1p와 3p] 밥값내세요!!";
                }
                else if((player == player2) && (player < player1))//232
                {
                    result = "[결과] 승자: [2p] 패자: [1p와 3p] 밥값내세요!!";
                }
                else if ((player == player1) && (player < player2))//223
                {
                    result = "[결과] 승자: [3p] 패자: [1p와 2p] 밥값내세요!!";
                }
                else if ((player1 == player2) && (player1 < player))//322
                {
                    result = "[결과] 승자: [1p] 패자: [2p와 3p] 밥값내세요!!";
                }
                else if ((player1 + 1) % 3 == player && player1 == player2) // 1 3 3
                {
                    result = "[결과] 승자: [1p] 패자: [2p와 3p] 밥값내세요!!";
                }
                else if ((player > player2 && player1 > player2) || (player2 > player && player2 > player1)) // 1 1 3  2 2 1  3 3 2
                {
                    result = "[결과] 승자: [1p와 2p] 패자: [3p] 밥값내세요!!";
                }
                else if (player > player1 && player2 > player1 || (player1 > player && player1 > player2)) // 1 3 1  2 1 2  3 2 3  
                {
                    result = "[결과] 승자: [1p와 3p] 패자: [2p] 밥값내세요!!";
                }
                else if ((player1 > player && player2 > player) || ((player + 1) % 3 == player1 && player1 == player2)) // 3 1 1  1 2 2  2 3 3 
                {
                    result = "[결과] 승자: [2p와 3p] 패자: [1p] 밥값내세요!!";
                }
            }
            return result;
        }
    }
}
