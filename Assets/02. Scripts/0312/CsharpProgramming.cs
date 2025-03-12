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
    }
}
