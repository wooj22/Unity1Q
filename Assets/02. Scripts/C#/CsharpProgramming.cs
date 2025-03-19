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

/* ----------- C# ���α׷��� �⺻ -------------- */
// Unity script X, visual studio���� �ۼ��ص� ������ ��
public class Program
{
    public void Main()
    {
        // �ֻ�����

        // I/O
        Console.WriteLine("Hello World!");

        // ����, �������
        int level = 1;
        const int MAX_COUNT = 10;
        float pi = 3.14f;
        char c = 'c';

        // ���ڿ�
        string s = "string";

        // ������ ũ�� Ȯ��
        Console.WriteLine(sizeof(char));

        // ����ȯ
        Console.WriteLine((int)pi);

        /// ����޸� ���� [�ڵ� - ����Ÿ - �� - ����]

        /// 1. Value Type (�� Ÿ��)
        /// int, flaot, char, struct...
        /// stack�� ����, ���ӵ� �޸�
        /// ������ ������ �� ��ü�� ����
        /// �ڵ� ����� ������ �ڵ����� �޸� ����

        /// 2. Reference Type (����Ÿ��)
        /// string, object, array, class...
        /// heap�� ����, ���� �Ҵ� -> �޸� ���� �ʿ�
        /// ������ �������� �޸� �ּҸ� ��� ����
        /// �ڵ� ����� ������ �����Ͱ� �����Ǹ�, ������ �÷��Ϳ� ���� ����

        // �迭�� foreach
        string[] Regions = { "����", "���", "�λ�" };
        foreach(var v in Regions)
        {
            Console.WriteLine(v);
        }

        // ���� for��
        for (int i = 1; i <= 9; i++)
        {
            for(int j = 1; j <= 9; j++)
            {
                Console.WriteLine(i + " * " + j + " = " + i * j);
            }
        }

        /// �÷��� : ���� ������ ������ ������ ��� �ڷᱸ��
        /// �迭�� �÷��� �ڷ� ����
        /// .NET �����ӿ�ũ�� �÷��� Ŭ����(�� �Ⱦ�) - ArrayList, Queue, Stack, Hashtable
        /// ���� ���׸� �������� ���� ����Ѵ�. - List<T>, Queue<T>, Stack<T>, Dictionary<TKey, TValue>
        /// List<T> �����迭�� Dictionary<TKey, TValue>�� ���� ���� �����. ����Ʈ ����.

        List<int> list = new List<int>() { 1, 2, 3 };
        foreach (var item in list) { }
        list.Clear();

        List<int> list2 = new List<int>(10);
        list2.Add(1);
        for (int i = 0; i < list2.Count; i++) { }

        // ��ü ����
        Calc cal = new Calc();
        int sum = cal.Add(1, 2);

        // Static ����
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

/* ----------- C# ��ü ���� -------------- */
class Program2
{
    public void Main()
    {
        // ��ü ����
        Cat kitty = new Cat();
        kitty.name = "";

        // ��ü �迭 - ����������
        Cat[] catArray = new Cat[3]
        {
            new Cat(){ name = "cat1", color = "white"},
            new Cat(){ name = "cat2", color = "black"},
            new Cat(){ name = "cat3", color = "yellow"}
        };

        // ��ü ����Ʈ (���׸�)  - ����������
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
    /// ��ü���� ���α׷��ֿ��� �⺻������ ��������� private�� ��Ģ�̴�.
    /// ������ �ܺο� �����Ҷ��� ���� getter�� setter�� ������ ������
    /// C#������ get, set�� �����Ͽ� ������Ƽ�� Ȱ���� �� �ְ� �Ѵ�.
    /// �ܺο����� �׳� ����ó�� ����ϸ� �ȴ�.

    public int myProperty { get; set; }    // ������Ƽ
    public int myProperty2
    {
        get { return myProperty2; }
        set { myProperty2 = 1; }
    }
    public string name;
    public string color;
    public void Meow() { Console.WriteLine("�̾߿�"); }
}


/* ----------- C# ���, ������ -------------- */
/// C#������ ���߻���� �Ұ����ϴ�. �ϳ��� ��ӹ��� ������. (C++�� ������ ����)
/// interface�� ������ ����� �� �ִ�. interface�� �ҿ�����.
/// ������ : �θ� �ڽĵ��� ������� ����, ����� �� �ִ� ����
/// override Ű���� : �θ��� �޼ҵ带 ������
/// override�� �� �Լ��� virtualŰ���带 �ٿ��� �Ѵ�.

class Program3
{
    public void Main()
    {
        // �޸𸮿� Base->Player ������ ����
        Player player = new Player();

        // ������ : BaseŬ������ ��ü�� ��� �����ϸ� �ڽĵ��� �޼ҵ�(override)���� Ȱ���� �� �ִ�.
        // �θ� Ŭ���� Ÿ�� ������ �ڽ� Ŭ������ �����ϴ� ��.
        Base b1 = new Player();
        Base b2 = new Monster();
        Base b3 = new Boss();

        b1.display();
        b2.display();
        b3.display();

        // �ڵ��� �̷��� ~
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
    public Base() { Debug.Log("Base ������ ȣ��\n"); }
    public virtual void display() { Debug.Log("Base display"); }
}

class Player : Base
{
    public Player() { Debug.Log("Player ������ ȣ��\n"); }
    public override void display()
    {
        base.display();
        Debug.Log("Player display");
    }
}
class Monster : Base
{
    private int skill;
    public Monster() { Debug.Log("Monster ������ ȣ��\n"); }
    public override void display()
    {
        base.display();
        Debug.Log("Monster display");
    }
}
class Boss : Base
{
    private int skill;
    public Boss() { Debug.Log("Boss ������ ȣ��\n"); }
    public override void display()
    {
        base.display();
        Debug.Log("Boss display");
    }
}


/// ����Ƽ�� ��ӱ��� ���� �� ������Ʈ ������� ������ ����������?
/// ���� �ڵ带 ������� �ʹ� ��������� ������Ʈ, ������ ���� ����� ��
/// �θ��� �ڽĿ� �θ��� �ڽĿ� �ڽĿ� ��¼�� ~... ������ ����!
/// �и��ؼ� ������Ʈ�� ������~!
/// ����� ���� �ʰ� Ŭ������ ����� Ȱ���ϴ� ����� ������
/// �� ��ɵ��� ���� �����ΰ� Component Ŭ������ ��ӹް� �ϰ�,
/// �� ��ɵ��� �����Ͽ� Ȱ���ϰ� �� (Component �迭�� �����ΰ� �� �ȿ� �ڽ�Ŭ����(�� ��ɵ��� Ŭ����)�� ����)

//class Camera : Component { }
//class Light : Component { }
//class Cube : Component { }

//class GameObject // : Camera, Light, Cube (������� �ٸ� Ŭ������ ����� Ȱ���Ҷ� ����� ����)
//{
//    // ������Ʈ ���
//    Component[] list;
//    void AddComponent(Component com) { 
//        // list�� �߰�
//    }
//}