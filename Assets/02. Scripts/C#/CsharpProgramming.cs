using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CsharpProgramming : MonoBehaviour
{
    private void Start()
    {
        Program program = new Program();
        program.Main();
    }
}

// C# 프로그래밍
// Unity script X, visual studio에서 작성해도 컴파일 ㅇ
public class Program
{
    public void Main()
    {
        // 최상위문

        // I/O
        Console.WriteLine("Hello World!");

        // 변수, 상수변수
        int level = 1;
        const int MAX_COUNT = 10;
        float pi = 3.14f;
        char c = 'c';

        // 문자열
        string s = "string";

        // 데이터 크기 확인
        Console.WriteLine(sizeof(char));

        // 형변환
        Console.WriteLine((int)pi);

        /// 가상메모리 영역 [코드 - 데이타 - 힙 - 스택]

        /// 1. Value Type (값 타입)
        /// int, flaot, char, struct...
        /// stack에 저장, 연속된 메모리
        /// 변수에 데이터 값 자체를 담음
        /// 코드 블록이 끝나면 자동으로 메모리 해제

        /// 2. Reference Type (참조타입)
        /// string, object, array, class...
        /// heap에 저장, 동적 할당 -> 메모리 관리 필요
        /// 변수에 데이터의 메모리 주소를 담고 있음
        /// 코드 블록이 끝나도 데이터가 유지되며, 가비지 컬렉터에 의해 해제

        // 배열과 foreach
        string[] Regions = { "서울", "경기", "부산" };
        foreach(var v in Regions)
        {
            Console.WriteLine(v);
        }

        // 이중 for문
        for (int i = 1; i <= 9; i++)
        {
            for(int j = 1; j <= 9; j++)
            {
                Console.WriteLine(i + " * " + j + " = " + i * j);
            }
        }

        /// 컬렉션 : 같은 성격의 데이터 모음을 담는 자료구조
        /// 배열도 컬렌션 자료 구조
        /// .NET 프레임워크의 컬렉션 클래스(잘 안씀) - ArrayList, Queue, Stack, Hashtable
        /// 보통 제네릭 형식으로 많이 사용한다. - List<T>, Queue<T>, Stack<T>, Dictionary<TKey, TValue>
        /// List<T> 동적배열과 Dictionary<TKey, TValue>를 가장 많이 사용함. 리스트 고마워.

        List<int> list = new List<int>() { 1, 2, 3 };
        foreach (var item in list) { }
        list.Clear();

        List<int> list2 = new List<int>(10);
        list2.Add(1);
        for (int i = 0; i < list2.Count; i++) { }

        // 객체 생성
        Calc cal = new Calc();
        int sum = cal.Add(1, 2);

        // Static 접근
        int val = Calc.GetVal();
    }
}

// 클래스와 객체지향 프로그래밍
class Calc
{
    private int a;
    private int b;
    public int Add(int a, int b) { return a + b; }

    private static int valStatic = 0;
    public static int GetVal() { return valStatic; }
}
