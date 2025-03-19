using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class CsharpProgramming : MonoBehaviour
{
    private void Start()
    {
        //Program p = new Program();
        //p.Main();

        //Program2 p1 = new Program2();
        //p1.Main();

        Program3 p2 = new Program3();
        p2.Main();
    }
}

/* ----------- C# 프로그래밍 기본 -------------- */
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

class Calc
{
    private int a;
    private int b;
    public int Add(int a, int b) { return a + b; }

    private static int valStatic = 0;
    public static int GetVal() { return valStatic; }
}

/* ----------- C# 객체 생성 -------------- */
class Program2
{
    public void Main()
    {
        // 객체 생성
        Cat kitty = new Cat();
        kitty.name = "";

        // 객체 배열 - 고정사이즈
        Cat[] catArray = new Cat[3]
        {
            new Cat(){ name = "cat1", color = "white"},
            new Cat(){ name = "cat2", color = "black"},
            new Cat(){ name = "cat3", color = "yellow"}
        };

        // 객체 리스트 (제네릭)  - 유동사이즈
        List<Cat> catList = new List<Cat>() 
        {
            new Cat(){ name = "cat1", color = "white"},
            new Cat(){ name = "cat2", color = "black"},
            new Cat(){ name = "cat3", color = "yellow"}
        };
        catList.Add(new Cat() { name = "cat4", color = "pink" });

    }
}

class Cat
{
    /// 객체지향 프로그래밍에서 기본적으로 멤버변수는 private이 원칙이다.
    /// 때문에 외부에 공개할때는 보통 getter와 setter를 만들어야 하지만
    /// C#에서는 get, set을 제공하여 프로퍼티로 활용할 수 있게 한다.
    /// 외부에서는 그냥 변수처럼 사용하면 된다.

    public int myProperty { get; set; }    // 프로퍼티
    public int myProperty2
    {
        get { return myProperty2; }
        set { myProperty2 = 1; }
    }
    public string name;
    public string color;
    public void Meow() { Console.WriteLine("미야옹"); }
}


/* ----------- C# 상속, 다형성 -------------- */
/// C#에서는 다중상속이 불가능하다. 하나만 상속받을 수있음. (C++은 여러개 가능)
/// interface는 여러개 사용할 수 있다. interface를 할용하자.
/// 다형성 : 부모가 자식들의 멤버들을 관리, 사용할 수 있는 개념
/// override 키워드 : 부모의 메소드를 재정의
/// override를 할 함수는 virtual키워드를 붙여야 한다.

class Program3
{
    public void Main()
    {
        // 메모리에 Base->Player 순서로 생성
        Player player = new Player();

        // 다형성 : Base클래스의 객체로 모두 관리하며 자식들의 메소드(override)까지 활용할 수 있다.
        // 부모 클래스 타입 변수에 자식 클래스를 생성하는 것.
        Base b1 = new Player();
        Base b2 = new Monster();
        Base b3 = new Boss();

        b1.display();
        b2.display();
        b3.display();

        // 코딩은 이렇게 ~
        Base[] baseList = { new Player(), new Monster(), new Boss() };
        foreach(var item in baseList)
        {
            item.display();
        }
    }
}

class Base
{
    protected string name;
    protected int hp = 0;
    public Base() { Debug.Log("Base 생성자 호출\n"); }
    public virtual void display() { Debug.Log("Base display"); }
}

class Player : Base
{
    public Player() { Debug.Log("Player 생성자 호출\n"); }
    public override void display()
    {
        base.display();
        Debug.Log("Player display");
    }
}
class Monster : Base
{
    private int skill;
    public Monster() { Debug.Log("Monster 생성자 호출\n"); }
    public override void display()
    {
        base.display();
        Debug.Log("Monster display");
    }
}
class Boss : Base
{
    private int skill;
    public Boss() { Debug.Log("Boss 생성자 호출\n"); }
    public override void display()
    {
        base.display();
        Debug.Log("Boss display");
    }
}


/// 유니티는 상속구조 말고 왜 컴포넌트 기반으로 엔진을 제작했을까?
/// 엔진 코드를 상속으로 너무 묶어버리면 업데이트, 수정에 많은 비용이 듦
/// 부모의 자식에 부모의 자식에 자식에 어쩌고 ~... 연결을 끊자!
/// 분리해서 컴포넌트로 만들자~!
/// 상속을 하지 않고 클래스를 멤버로 활용하는 방식을 선택함
/// 각 기능들을 따로 만들어두고 Component 클래스를 상속받게 하고,
/// 그 기능들을 조립하여 활용하게 함 (Component 배열을 만들어두고 그 안에 자식클래스(각 기능들의 클래스)를 담음)

//class Camera : Component { }
//class Light : Component { }
//class Cube : Component { }

//class GameObject // : Camera, Light, Cube (원래라면 다른 클래스의 기능을 활용할때 상속을 받음)
//{
//    // 컴포넌트 기반
//    Component[] list;
//    void AddComponent(Component com) { 
//        // list에 추가
//    }
//}