using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace LunchMate_Server
{
    class Server
    {
        static object keyObj = new object();
        static string playerNum = "10";
        static string[] player = new string[3];
        static List<Socket> socketList = new List<Socket>();
        static Dictionary<string, Socket> idMap = new Dictionary<string, Socket>();
        static Dictionary<Socket, string> socketMap = new Dictionary<Socket, string>();
        static Dictionary<string, string> rockScissorPaperMap = new Dictionary<string, string>();

        const int PORT = 9000;
        static int _player1, _player2, _player3;
        static void Main(string[] args)
        {
            Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            IPEndPoint ipep = new IPEndPoint(IPAddress.Any, PORT);

            serverSocket.Bind(ipep);
            serverSocket.Listen(100);
            while(true)
            {
                Console.WriteLine("[서버] 접속 대기중...");
                Socket connSocket = serverSocket.Accept();

                // 임계영역 동기화
                Monitor.Enter(keyObj);
                socketList.Add(connSocket);
                Monitor.Exit(keyObj);

                Console.WriteLine("[서버] 클라이언트 접속 연결~");
                Thread thread = new Thread(new ParameterizedThreadStart(threadRead));
                thread.Start(connSocket);
                Console.WriteLine("[서버] 클라이언트 스레드 담당~");
            }
            static void threadRead(object sock)
            {
                Socket connSocket = (Socket)sock;
                NetworkStream ns = new NetworkStream(connSocket);
                StreamReader sr = new StreamReader(ns);// ReadLine()
                StreamWriter sw = new StreamWriter(ns);// WriteLine()

                try  // 정상 실행을 시도
                {
                    bool isRun = true;
                    while (isRun)
                    {
                        String strMsg = sr.ReadLine();
                        Console.WriteLine("[서버] : 수신 : " + strMsg);

                        isRun = processPacket(strMsg, connSocket, sw, sr);

                        if (strMsg == null)
                            break;
                    }
                }
                catch (Exception e) // 예외 발생이 여기로 점프
                {
                    Console.WriteLine(e.Message);
                }
                finally // 정상,예외 모두 무조건 최종 실행되는 구문
                {
                    // 연결이 종료된 소켓을 리스트에서 제거
                    removeRegisterSocket(connSocket);

                    Console.WriteLine("[서버] 클라이언트 접속 종료...");
                    if (sr != null) sr.Close();
                    if (ns != null) ns.Close();
                    if (connSocket != null) connSocket.Close();
                }
            }

            static void removeRegisterSocket(Socket connSocket)
            {
                Monitor.Enter(keyObj);

                socketList.Remove(connSocket);

                string id = socketMap[connSocket];

                socketMap.Remove(connSocket);
                idMap.Remove(id);

                Monitor.Exit(keyObj);
            }

            static bool processPacket(String strPacket, Socket connSocket, StreamWriter sw, StreamReader sr)
            {
                bool isRun = true;
                String[] dataArr = strPacket.Split(new char[] { '|' });
                string result = "";
                string id = "";
                string cmd = dataArr[0];
                string subCmd = dataArr[1];
                switch (cmd)
                {
                    case "I":            //아이디 가입
                        id = dataArr[1];
                        Console.WriteLine("[서버] 클라이언트 id 수신 : " + id);
                        moveListToMap(connSocket, id);
                        break;
                    case "C":           // 채팅
                        subCmd = dataArr[1];
                        if (subCmd == "E")
                        {
                            bool isEnable = isChatting(connSocket);
                            if (isEnable)
                                sw.WriteLine("C|O");
                            else
                                sw.WriteLine("C|F");
                            sw.Flush();
                        }
                        else if (subCmd == "M")
                        {
                            bool isEnable = isChatting(connSocket);
                            if (isEnable)
                            {
                                string msg = dataArr[2];
                                sendAllMsg(msg, connSocket);
                            }
                            else
                            {
                                sw.WriteLine("C|F");
                                sw.Flush();
                            }
                        }
                        break;
                    case "W":
                        subCmd = dataArr[1];
                        if (subCmd == "E")
                        {
                            bool isEnable = isChatting(connSocket);
                            if (isEnable)
                                sw.WriteLine("W|O");
                            else
                                sw.WriteLine("W|F");
                            sw.Flush();
                        }
                        else if (subCmd == "L")
                        {
                            sendWhisperIdList(sw, connSocket);
                        }
                        else if (subCmd == "M")
                        {
                            bool isEnable = isChatting(connSocket);
                            if (isEnable)
                            {
                                string receiveId = dataArr[2];
                                string msg = dataArr[3];
                                sendWhisper(msg, connSocket, receiveId);
                            }
                            else
                            {
                                sw.WriteLine("W|F");
                                sw.Flush();
                            }
                        }
                        break;
                    case "G":
                        subCmd = dataArr[1];
                        string thirdCmd = dataArr[2];
                        string fourthCmd = dataArr[3];
                        if (subCmd == "E")
                        {
                            bool isEnableGame = isChatting(connSocket);
                            if (isEnableGame)
                                sw.WriteLine("G|O|1");
                            else
                                sw.WriteLine("G|F|1");
                            sw.Flush();
                        }
                        else if (subCmd == "P")
                        {
                            bool isEnableGame = isChatting(connSocket);
                            JudgeGame judgeGame = new JudgeGame();
                            //int result = Int32.Parse(dataArr[2]);

                            Console.WriteLine("[서버]게임접속을 하였습니다.");
                            if (thirdCmd == "R")
                            {
                                Console.WriteLine("[서버]가위바위보에 접속");
                                Monitor.Enter(keyObj);


                                if (player[0] == null)
                                { 
                                    player[0] = fourthCmd;

                                    for(int i = 0; i < player.Length; i++)
                                    {
                                        Console.WriteLine(player[i]);
                                    }
                                     playerNum = "1";
                                }
                                else if (player[1] == null)
                                {
                                    player[1] = fourthCmd;
                                    for (int i = 0; i < player.Length; i++)
                                    {
                                        Console.WriteLine(player[i]);
                                    }
                                    playerNum = "2";
                                }
                                else if (player[2] == null)
                                {
                                    player[2] = fourthCmd;
                                    for (int i = 0; i < player.Length; i++)
                                    {
                                        Console.WriteLine(player[i]);
                                    }
                                    playerNum = "3";
                                }

                                Console.WriteLine(playerNum);
                                string packet = String.Format("G|O|{0}", playerNum);
                                sw.WriteLine(packet);
                                sw.Flush();

                                Console.Write("플레이어번호는:" + playerNum);

                                for (int i = 0; i < player.Length; i++)
                                {
                                    Console.WriteLine($"    {i+1}플레이어의 값은 " + player[i]);
                                }
                               
                                if (playerNum == "3")
                                {
                                    for (int i = 0; i < player.Length; i++)
                                    {
                                        Console.WriteLine($"{i + 1}플레이어의 값은 " + player[i]);

                                        if (i == 0)
                                            _player1 = Int32.Parse(player[0]);
                                        if (i == 1)
                                            _player2 = Int32.Parse(player[1]);
                                        if (i == 2)
                                            _player3 = Int32.Parse(player[2]);
                                    }
                                      result = judgeGame._1_RockScissorPaper(_player1, _player2, _player3);

                                    sendAllResultIncludeMe(result, connSocket);
                                    Console.WriteLine(result);

                                    // 초기화 작업
                                    playerNum = null;
                                    for (int i = 0; i < player.Length; i++)
                                    {
                                        player[i] = null;
                                    }
                                }
                                Console.WriteLine("계산 끝");

                                Monitor.Exit(keyObj);

                            }
                            else if (thirdCmd == "D")
                            {
                                Console.WriteLine("제비뽑기에 접속");
                            }
                            else if (thirdCmd == "M")
                            {
                                Console.WriteLine("짝 맞추기 접속");
                            }
                            else if (thirdCmd == "W")
                            {
                                Console.WriteLine("눈치게임 접속");
                            }
                        }
                        break;
                    case "E":
                        Console.WriteLine("[서버] 클라이언트 종료 요청");
                        isRun = false;
                        break;
                }

                return isRun;
            }

            static void moveListToMap(Socket connSocket, string id)
            {
                Monitor.Enter(keyObj);
                socketList.Remove(connSocket);
                idMap.Add(id, connSocket);
                socketMap.Add(connSocket, id);
                Monitor.Exit(keyObj);
            }

            static bool isChatting(Socket connSocket)
            {
                bool isEnable = true;
                Monitor.Enter(keyObj);
                foreach (Socket socket in socketList)
                {
                    if (socket == connSocket)
                    {
                        isEnable = false;
                        break;
                    }
                }
                Monitor.Exit(keyObj);

                return isEnable;
            }

            static void sendWhisperIdList(StreamWriter sw, Socket exceptionSocket)
            {
                Monitor.Enter(keyObj);

                string packet = "W|L|";
                foreach (var data in idMap)
                {
                    string id = data.Key;
                    Socket socket = data.Value;
                    if (socket != exceptionSocket)
                    {
                        packet += id + "|";
                    }
                }

                sw.WriteLine(packet);
                sw.Flush();

                Monitor.Exit(keyObj);
            }

            static void sendWhisper(string strMsg, Socket sendSocket, string receiveId)
            {
                Monitor.Enter(keyObj);

                string sendId = socketMap[sendSocket];

                Socket receiveSocket = idMap[receiveId];

                NetworkStream ns = new NetworkStream(receiveSocket);
                StreamWriter sw = new StreamWriter(ns);

                sw.WriteLine(String.Format("W|M|[{0} whisper] {1}", sendId, strMsg));
                sw.Flush();
                
                Monitor.Exit(keyObj);
            }

            static void sendAllMsg(String strMsg, Socket exceptionSocket)
            {
                Monitor.Enter(keyObj);

                string sendId = socketMap[exceptionSocket];

                foreach (var data in idMap)
                {
                    string id = data.Key;
                    Socket socket = data.Value;
                    if (id != sendId)
                    {
                        NetworkStream ns = new NetworkStream(socket);
                        StreamWriter sw = new StreamWriter(ns);
                        sw.WriteLine(String.Format("C|M|[{0}] {1}", sendId, strMsg));
                        sw.Flush();
                    }
                }
                Monitor.Exit(keyObj);
            }

            static void sendAllResultIncludeMe(string result, Socket sendSocket)
            {
                Monitor.Enter(keyObj);

                string sendId = socketMap[sendSocket];

                foreach (var data in idMap)
                {
                    string id = data.Key;
                    Socket socket = data.Value;
                    NetworkStream ns = new NetworkStream(socket);
                    StreamWriter sw = new StreamWriter(ns);
                    sw.WriteLine(String.Format("{0}", result));
                    sw.Flush();
                }
                Monitor.Exit(keyObj);
            }

            static void sendAllResult(string result, Socket exceptionSocket)
            {
                Monitor.Enter(keyObj);

                string sendId = socketMap[exceptionSocket];

                foreach (var data in idMap)
                {
                    string id = data.Key;
                    Socket socket = data.Value;
                    if (id != sendId)
                    {
                        NetworkStream ns = new NetworkStream(socket);
                        StreamWriter sw = new StreamWriter(ns);
                        sw.WriteLine(String.Format("{0}", result));
                        sw.Flush();
                    }
                }
                Monitor.Exit(keyObj);
            }
        }
    }
}
