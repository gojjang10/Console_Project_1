namespace Zelda
{
    internal class Program
    {
        enum Direction { Left, Right, Up, Down }
        enum Scean { village, cave, dungeon }
        enum Ganon { fire, thunder, blackmagic}

        struct GameData
        {

            public bool running; //게임이 끝났는지 안끝났는지

            public int[,] map; // 2차원 배열
            public Scean scean; // 여러개의 맵
            public bool staytMap; // 다음 맵으로 전환 시킬지 말지 결정

            public Position playerPosition; //플레이어 위치
            public Position itemPosition; //아이템 위치
            public Position monsterPosition; //몬스터 위치
            public Position clearPosition; //클리어 위치

            public ConsoleKey key; //입력을 위한 키

            public bool sword; // 검을 얻었는지 여부 확인
            public bool next; // 플레이어의 이동이 자연스럽게 하기 위한 변수

        }

        struct Position // 좌표
        {
            public int x;
            public int y;
        }

        struct Stats //전투 스탯
        {
            public int playerHP; 
            public int playerSTR;
            public int monsterHP;
            public int monsterSTR;
        }

        static GameData data; //함수에서 사용할 수 있게 만들기
        static void Start()
        {
            data.running = true; //게임 실행중

            Console.CursorVisible = false; //커서는 안보이게
            Console.WriteLine("==========================================================================================");
            Console.WriteLine("                                               *                                          ");
            Console.WriteLine("                                              ***                                         ");
            Console.WriteLine("                                             *****                                        ");
            Console.WriteLine("                                            *******                                       ");
            Console.WriteLine("                                           *********                                      ");
            Console.WriteLine("                                          ***********                                     ");
            Console.WriteLine("                                         *************                                    ");
            Console.WriteLine("                                        ***************                                   ");
            Console.WriteLine("                                       *               *                                  ");
            Console.WriteLine("                                      ***             ***                                 ");
            Console.WriteLine("                                     *****           *****                                ");
            Console.WriteLine("                                    *******         *******                               ");
            Console.WriteLine("                                   *********       *********                              ");
            Console.WriteLine("                                  ***********     ***********                             ");
            Console.WriteLine("                                 *************   *************                            ");
            Console.WriteLine("                                *******************************                           ");
            Console.WriteLine("                                                                                          ");
            Console.WriteLine("                                                                                          ");
            Console.WriteLine("                                      The Legend Of Zelda                                 ");
            Console.WriteLine("                                                                                          ");
            Console.WriteLine("                                                                                          ");
            Console.WriteLine("==========================================================================================");
                                                                  
            Console.WriteLine("Please any key");                  
            Console.ReadKey(true);

            Console.Clear(); // 콘솔 창 정리
            Console.WriteLine("링크...");
            Wait(1);
            Console.WriteLine("눈을 뜨세요........ ");
            Wait(1);
            Console.WriteLine("가논을 쓰러트리고 하이랄을 되찾아 주세요........");
            Wait(2);
           
            data.scean = Scean.village; //게임 씬을 마을로 설정해놓기

        }


        static void Main(string[] args)
        {
            Start(); //게임 시작

            while (data.running)
            {
                Run();
            }

            End(); //게임 끝
        }

        static void Run()
        {
            Console.Clear(); // 콘솔 창 정리

                

            switch (data.scean) 
            {
                case Scean.village:
                    VillageScean();
                    break;
                case Scean.cave:
                    CaveScean();
                    break;
                case Scean.dungeon:
                    DungeonScean();
                    break;
            }

        }

        static void VillageScean() // 마을 맵
        {
            
            data.playerPosition = new Position() { x = 2, y = 6 };
            
            if (data.next == true)
            {
                data.playerPosition = new Position() { x = 2, y = 2 };
            }
            data.staytMap = true;
            data.map = new int[,]
            {
                { 1 , 1 , 1 , 1 , 1 , 1 , 1 , 1 , 1 , 1 , 1 , 1 , 1 , 1 , 1 , 1 , 1 , 1 , 1 , 1 },
                { 1 , 0 , 2 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 1 },
                { 1 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 1 , 1 , 0 , 1 , 0 , 1 },
                { 1 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 1 , 0 , 0 , 0 , 1 , 1 , 0 , 0 , 0 , 1 },
                { 1 , 1 , 1 , 1 , 0 , 0 , 0 , 0 , 0 , 1 , 1 , 1 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 1 },
                { 1 , 0 , 0 , 1 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 5 , 1 },
                { 1 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 1 , 1 , 0 , 0 , 0 , 1 },
                { 1 , 1 , 1 , 1 , 1 , 1 , 1 , 1 , 1 , 1 , 1 , 1 , 1 , 1 , 1 , 1 , 1 , 1 , 1 , 1 },

            };
            while (data.staytMap == true)
            {
                Render();
                Input();
                Move();
            }

        }
        static void CaveScean() // 동굴 맵
        {
            
            data.playerPosition = new Position() { x = 12, y = 10 };
            data.next = true;
            data.staytMap  = true;
            data.map = new int[,]
            {
                { 1 , 1 , 1 , 1 , 1 , 1 , 1 , 1 , 1 , 1 , 1 , 1 , 1 , 1 , 1 },
                { 1 , 0 , 0 , 0 , 0 , 0 , 0 , 3 , 0 , 0 , 0 , 0 , 0 , 0 , 1 },
                { 1 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 1 , 0 , 1 },
                { 1 , 0 , 0 , 0 , 1 , 0 , 0 , 0 , 0 , 0 , 1 , 0 , 0 , 0 , 1 },
                { 1 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 1 , 1 , 0 , 0 , 0 , 1 },
                { 1 , 1 , 1 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 1 , 0 , 1 },
                { 1 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 1 , 1 , 1 , 0 , 1 },
                { 1 , 0 , 0 , 1 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 1 },
                { 1 , 0 , 0 , 1 , 1 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 1 },
                { 1 , 1 , 0 , 0 , 0 , 0 , 0 , 0 , 1 , 0 , 0 , 0 , 0 , 0 , 1 },
                { 1 , 1 , 1 , 0 , 0 , 0 , 0 , 1 , 1 , 0 , 0 , 0 , 0 , 0 , 4 },
                { 1 , 1 , 1 , 1 , 1 , 1 , 1 , 1 , 1 , 1 , 1 , 1 , 1 , 1 , 1 }
            };
            if (data.sword == true)
            {
                data.map[1, 7] = 0; // 칼을 얻었을땐 맵에 칼이 없게 만들기
            }

            while (data.staytMap == true)
            {
                Render();
                Input();
                Move();
            }

        }
        static void DungeonScean() // 던전 맵
        {
            
            data.playerPosition = new Position() { x = 1, y = 5 };
            data.staytMap = true;
            
            data.map = new int[,]
            {
                { 1 , 1 , 1 , 1 , 1 , 1 , 1 , 1 , 1 , 1 , 1 , 1 , 1 , 1 , 1 , 1 , 1 , 1 , 1 , 1 , 1 , 1 , 1 , 1 , 1 , 1},
                { 1 , 1 , 1 , 1 , 1 , 0 , 0 , 1 , 0 , 0 , 0 , 0 , 0 , 0 , 1 , 0 , 0 , 0 , 1 , 1 , 0 , 0 , 0 , 0 , 0 , 1},
                { 1 , 0 , 1 , 0 , 0 , 0 , 0 , 1 , 0 , 0 , 1 , 0 , 0 , 0 , 1 , 0 , 0 , 0 , 1 , 1 , 0 , 0 , 0 , 0 , 0 , 1},
                { 1 , 0 , 1 , 0 , 0 , 0 , 0 , 1 , 1 , 0 , 0 , 1 , 1 , 0 , 1 , 0 , 0 , 0 , 1 , 1 , 0 , 0 , 0 , 0 , 0 , 1},
                { 1 , 0 , 1 , 0 , 0 , 0 , 0 , 0 , 0 , 1 , 0 , 0 , 1 , 0 , 1 , 0 , 0 , 0 , 1 , 1 , 0 , 0 , 0 , 0 , 0 , 1},
                { 1 , 0 , 1 , 0 , 0 , 0 , 0 , 0 , 0 , 1 , 0 , 0 , 1 , 0 , 1 , 0 , 0 , 0 , 1 , 0 , 0 , 0 , 0 , 6 , 0 , 1},
                { 1 , 0 , 1 , 0 , 1 , 1 , 1 , 1 , 0 , 1 , 0 , 0 , 1 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 1 , 0 , 0 , 0 , 1},
                { 1 , 0 , 0 , 0 , 1 , 1 , 1 , 0 , 0 , 0 , 0 , 0 , 1 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 1 , 0 , 0 , 0 , 1},
                { 1 , 0 , 0 , 1 , 1 , 0 , 0 , 0 , 0 , 1 , 1 , 0 , 1 , 1 , 0 , 0 , 1 , 1 , 0 , 0 , 0 , 1 , 0 , 0 , 0 , 1},
                { 1 , 0 , 0 , 1 , 1 , 1 , 0 , 0 , 0 , 0 , 1 , 0 , 1 , 1 , 0 , 1 , 0 , 0 , 1 , 0 , 1 , 0 , 0 , 0 , 0 , 1},
                { 1 , 0 , 1 , 0 , 0 , 1 , 1 , 0 , 0 , 0 , 1 , 0 , 1 , 1 , 1 , 0 , 0 , 0 , 1 , 0 , 1 , 0 , 0 , 0 , 0 , 1},
                { 1 , 1 , 1 , 1 , 1 , 1 , 1 , 1 , 1 , 1 , 1 , 1 , 1 , 1 , 1 , 1 , 1 , 1 , 1 , 1 , 1 , 1 , 1 , 1 , 1 , 1}
            };
            while (data.staytMap == true)
            {
                Render();
                Input();
                Move();
            }
            data.running = false;
        }

        static void Render()
        {
            Console.Clear();

            PrintMap();
            PlayerPosition();

        }


        static void PrintMap()
        {
            for (int y = 0; y < data.map.GetLength(0); y++) // 줄 반복
            {
                for (int x = 0; x < data.map.GetLength(1); x++) // 칸 반복
                {
                    if (data.map[y, x] == 0)
                    {
                        
                        Console.Write(" ");
                    }
                    else if (data.map[y, x] == 1)
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("■");
                        Console.BackgroundColor = ConsoleColor.Black;
                    }
                    else if (data.map[y, x] == 2) // 동굴(cave)로
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("●");
                        Console.ResetColor();
                    }
                    else if (data.map[y, x] == 3) // 아이템 획득
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("↓");
                        Console.ResetColor();
                    }
                    else if (data.map[y, x] == 4) // 마을(village)로
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("●");
                        Console.ResetColor();
                    }
                    else if (data.map[y, x] == 5) // 던전(dungeon)으로
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("●");
                        Console.ResetColor();
                    }
                    else if (data.map[y, x] == 6) // 가논과 조우
                    {
                        Console.ForegroundColor= ConsoleColor.Red;
                        Console.Write("◈");
                        Console.ResetColor();
                    }
                }
                Console.WriteLine();
            }
        }
        static void PlayerPosition() // 플레이어 위치 그리기
        {
            Console.SetCursorPosition(data.playerPosition.x, data.playerPosition.y);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("●");
            Console.ResetColor();
        }


        static void Input()
        {
            data.key = Console.ReadKey(true).Key;
        }

        static void Move() 
        {
            switch (data.key)
            {
                case ConsoleKey.W:
                case ConsoleKey.UpArrow:
                    FourDirection(Direction.Up);
                    break;

                case ConsoleKey.S:
                case ConsoleKey.DownArrow:
                    FourDirection(Direction.Down); ;
                    break;

                case ConsoleKey.A:
                case ConsoleKey.LeftArrow:
                    FourDirection(Direction.Left);
                    break;

                case ConsoleKey.D:
                case ConsoleKey.RightArrow:
                    FourDirection(Direction.Right);
                    break;

            }
        }
        static void FourDirection(Direction direction)
        {
            Position next = new Position();
            switch (direction)
            {
                case Direction.Left:
                    next = new Position() { x = data.playerPosition.x - 1, y = data.playerPosition.y };
                    Acting(next);
                    break;
                case Direction.Right:
                    next = new Position() { x = data.playerPosition.x + 1, y = data.playerPosition.y };
                    Acting(next);
                    break;
                case Direction.Up:
                    next = new Position() { x = data.playerPosition.x, y = data.playerPosition.y - 1 };
                    Acting(next);
                    break;
                case Direction.Down:
                    next = new Position() { x = data.playerPosition.x, y = data.playerPosition.y + 1 };
                    Acting(next);
                    break;
            }
        }

        static void Acting(Position next) //움직이는 조건
        {
            
            if (data.map[next.y, next.x] == 0)
            {
                data.playerPosition = next;
            }
            else if (data.map[next.y, next.x] == 1)
            {
                return;
            }
            else if (data.map[next.y, next.x] == 2)
            {
                data.scean = Scean.cave;
                data.staytMap = false;

            }
            else if (data.map[next.y, next.x] == 3)
            {
                SwordOutput(); // 검 텍스트 출력
                data.sword = true;

                data.map[next.y, next.x] = 0;
            }
            else if (data.map[next.y, next.x] == 4)
            {

                data.scean = Scean.village;
                data.staytMap = false;
            }
            else if (data.map[next.y, next.x] == 5)
            {
                if (data.sword)
                {
                    data.scean = Scean.dungeon;
                    data.staytMap = false;
                }
                else // 검을 얻지 못한채로 진입을 시도할때
                {
                    Console.Clear();
                    Console.Write("위험해보인다. 나를 지킬 수 있는 것을 찾아보자.");
                    Wait(3);
                    return;
                }
            }
            else if (data.map[next.y, next.x] == 6)
            {
                
                Fight();
            }

        }

        static void Wait(float seconds)
        {
            Thread.Sleep((int)(seconds * 1000)); // 기다리기
        }



        static void Fight()
        {
            Stats stats = new Stats();
            Random random = new Random();
            Ganon[] ganon = { Ganon.fire, Ganon.thunder, Ganon.thunder };
            Ganon randomValue = ganon[random.Next(0, ganon.Length)]; // 가논이 한가지 공격이 아닌 여러 공격을 할 수 있게 만들기

            stats.playerHP = 20;    // 플레이어 체력
            stats.monsterHP = 20;   // 몬스터 체력

            stats.playerSTR = random.Next(5, 10);
            stats.monsterSTR = random.Next(5, 10);

            Console.Clear();
            Console.WriteLine("던전의 끝에서 가논을 만났다");
            

            while (stats.playerHP > 0 || stats.monsterHP > 0)
            {
                Wait(1);
                Console.Clear() ;
                Console.WriteLine($"현재 링크의 HP : {stats.playerHP}");
                Console.WriteLine($"현재 가논의 HP : {stats.monsterHP}");
                Console.WriteLine("\n행동을 고르세요");
                Console.WriteLine("\n1. 공격\n2. 방어(성공 시 HP회복)");
                bool correct = int.TryParse(Console.ReadLine(), out int action);

                if (correct && action > 0 && action < 3)
                {
                    switch (action)
                    {
                        case 1:
                            Console.WriteLine("\n공격을 진행합니다.");
                            if (stats.playerSTR > stats.monsterSTR)
                            {
                                Wait(1);
                                Console.WriteLine("\n공격에 성공하였습니다.");
                                stats.monsterHP -= stats.playerSTR;
                            }
                            else
                            {
                                Wait(1);
                                Console.WriteLine("\n공격에 실패하였습니다.");
                                Wait(1);
                                Console.WriteLine($"\n가논이 {randomValue}를 사용하였습니다.");
                                randomValue = ganon[random.Next(0, ganon.Length)];
                                stats.playerHP -= stats.monsterSTR;
                            }
                            

                            stats.playerSTR = random.Next(5, 10);
                            stats.monsterSTR = random.Next(5, 10);
                            break;
                        case 2:
                            Console.WriteLine("\n방어를 진행합니다.");
                            if(stats.monsterSTR < stats.playerSTR)
                            {
                                Wait(1);
                                Console.WriteLine();
                                Console.WriteLine("\n방어에 성공하였습니다.");
                                stats.playerHP += stats.playerSTR;
                                stats.playerHP -= stats.monsterSTR;
                            }
                            else
                            {
                                Wait(1);
                                Console.WriteLine();
                                Console.WriteLine("\n방어에 실패하였습니다.");
                                Wait(1);
                                Console.WriteLine($"\n가논이 {randomValue}를 사용하였습니다.");
                                randomValue = ganon[random.Next(0, ganon.Length)];
                                stats.playerHP -= stats.monsterSTR;
                            }

                            stats.playerSTR = random.Next(5, 10);
                            stats.monsterSTR = random.Next(5, 10);
                            break;

                    }
                }
                if (stats.playerHP <= 0)
                {
                    Console.WriteLine("전투에서 패배하였습니다");
                    Wait(2);
                    return;
                }
                if (stats.monsterHP <= 0)
                {
                    Console.WriteLine("전투에서 승리하였습니다.");
                    Wait(2);
                    data.staytMap = false;
                    return;
                }
            }
        }
        static void SwordOutput()
        {
            Console.Clear();
            Console.WriteLine("======================================");
            Console.WriteLine("                                         ");
            Console.WriteLine("                   *                   ");
            Console.WriteLine("                  ***                     ");
            Console.WriteLine("                 *****                      ");
            Console.WriteLine("                  ***                  ");
            Console.WriteLine("                  ***                     ");
            Console.WriteLine("            ***** *** *****                   ");
            Console.WriteLine("           **   *******   **                  ");
            Console.WriteLine("          *       ***       *              ");
            Console.WriteLine("                  ***                     ");
            Console.WriteLine("                 *****                     ");
            Console.WriteLine("                 *****                     ");
            Console.WriteLine("                  ***                     ");
            Console.WriteLine("                  ***                      ");
            Console.WriteLine("                  ***                     ");
            Console.WriteLine("                  ***                     ");
            Console.WriteLine("                  ***                     ");
            Console.WriteLine("                  ***                     ");
            Console.WriteLine("                  ***                     ");
            Console.WriteLine("                  ***                     ");
            Console.WriteLine("                  ***                     ");
            Console.WriteLine("                  ***                     ");
            Console.WriteLine("                  ***                    ");
            Console.WriteLine("                   *                     ");
            Console.WriteLine("                                         ");
            Console.WriteLine("======================================");
            Console.WriteLine("땅에 꽂혀있는 성검 마스터 소드를 얻었다!");
            Wait(2);

            Console.WriteLine("\n검을 뽑은자여...\n");
            Wait(2);
            Console.WriteLine("정진하여라...!\n");
            Wait(3);
        }// 검 텍스트

        static void End()
        {
            Console.Clear();

            Console.WriteLine("하이랄 대륙에 안개가 걷히고..");
            Wait(2);
            Console.WriteLine("파란 하늘과 함께 빛을 띄기 시작합니다...");
            Wait(2);

            Console.WriteLine("==========================================================================================");
            Console.WriteLine("                                                                                          ");
            Console.WriteLine("                                       Game Over                                          ");
            Console.WriteLine("                                                                                          ");
            Console.WriteLine("==========================================================================================");
        }


    }

}



