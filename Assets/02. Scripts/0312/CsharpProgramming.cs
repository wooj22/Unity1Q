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
    }
}
