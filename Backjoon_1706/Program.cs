using System;
/*
 동혁이는 크로스워드 퍼즐을 좋아한다. R×C 크기의 크로스워드 퍼즐을 생각해 보자. 
이 퍼즐은 R×C 크기의 표로 이루어지는데, 퍼즐을 다 풀면 금지된 칸을 제외하고는 각 칸에 알파벳이 하나씩 적혀 있게 된다. 
아래는 R = 5, C = 5 인 경우 다 푼 퍼즐의 한 예이다. 검은 칸은 금지된 칸이다.

5 5
good#
an##b
messy
e##it
#late

세로 또는 가로로 연속되어 있고, 더 이상 확장될 수 없는 낱말이 퍼즐 내에 존재하는 단어가 된다. 위의 퍼즐과 같은 경우, 
가로 낱말은 good, an, messy, it, late의 5개가 있고, 세로 낱말은 game, one, sit, byte의 4개가 있다. 
이 중 사전식 순으로 가장 앞서 있는 낱말은 an이다.

다 푼 퍼즐이 주어졌을 때, 퍼즐 내에 존재하는 모든 낱말 중 사전식 순으로 가장 앞서 있는 낱말을 구하는 프로그램을 작성하시오.

입력
첫째 줄에는 퍼즐의 R과 C가 빈 칸을 사이에 두고 주어진다. (2 ≤ R, C ≤ 20) 이어서 R개의 줄에 걸쳐 다 푼 퍼즐이 주어진다. 
각 줄은 C개의 알파벳 소문자 또는 금지된 칸을 나타내는 #로 이루어진다. 낱말이 하나 이상 있는 입력만 주어진다.

출력
첫째 줄에 사전식 순으로 가장 앞서 있는 낱말을 출력한다.

예제 입력 1 
4 5
adaca
da##b
abb#b
abbac

예제 출력 1 
abb
 */


namespace Backjoon_1706
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var tableSizeInputs = Console.ReadLine().Split(' ');

            int row, col;

            row = int.Parse(tableSizeInputs[0]);
            col = int.Parse(tableSizeInputs[1]);

            char[,] puzzleTable = new char[row, col];

            ReadPuzzleTable(puzzleTable);

            string fastestWordInOrder = "zzzzzzzzzzzzzzzzzzzz";

            for (int r = 0; r < row; r++)
            {
                string currentWord = "";

                for (int c = 0; c < col; c++)
                {
                    if (puzzleTable[r, c] == '#')
                    {
                        if (currentWord.Length > 1 && currentWord.CompareTo(fastestWordInOrder) == -1)
                        {
                            fastestWordInOrder = currentWord; Console.WriteLine($"fastestWordInOrder : {fastestWordInOrder}");
                        }

                        currentWord = "";
                    }
                    else
                    {
                        currentWord = $"{currentWord}{puzzleTable[r, c]}";
                    }

                    Console.WriteLine($"currentWord : {currentWord}");
                }

                if (currentWord.Length > 1 && currentWord.CompareTo(fastestWordInOrder) == -1)
                {
                    fastestWordInOrder = currentWord; Console.WriteLine($"fastestWordInOrder : {fastestWordInOrder}");
                }
                Console.WriteLine();
            }

            for (int c = 0; c < col; c++)
            {
                string currentWord = "";

                for (int r = 0; r < row; r++)
                {
                    if (puzzleTable[r, c] == '#')
                    {
                        if (currentWord.Length > 1 && currentWord.CompareTo(fastestWordInOrder) == -1)
                        {
                            fastestWordInOrder = currentWord; Console.WriteLine($"fastestWordInOrder : {fastestWordInOrder}");
                        }
                        
                        currentWord = "";
                    }
                    else
                    {
                        currentWord = $"{currentWord}{puzzleTable[r, c]}";
                    }

                    Console.WriteLine($"currentWord : {currentWord}");
                }

                if (currentWord.Length > 1 && currentWord.CompareTo(fastestWordInOrder) == -1)
                {
                    fastestWordInOrder = currentWord; Console.WriteLine($"fastestWordInOrder : {fastestWordInOrder}");
                }
               Console.WriteLine();
            }


            Console.Write(fastestWordInOrder);
        }


        static void ReadPuzzleTable(char[,] puzzleTable)
        {
            for (int r = 0; r < puzzleTable.GetLength(0); r++)
            {
                string alphabetsInRow = Console.ReadLine();

                for (int c = 0; c < puzzleTable.GetLength(1); c++)
                {
                    puzzleTable[r, c] = alphabetsInRow[c]; 
                }
            }
        }
    }
}
