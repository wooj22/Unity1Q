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

// C# ���α׷���
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

// Ŭ������ ��ü���� ���α׷���
class Calc
{
    private int a;
    private int b;
    public int Add(int a, int b) { return a + b; }

    private static int valStatic = 0;
    public static int GetVal() { return valStatic; }
}
