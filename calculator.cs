using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Windows;

public class calculator : MonoBehaviour
{
    private GUIStyle labelStyle;//�ı�����ʾ���ֵĴ�С��λ��
    private GUIStyle buttonStyle;//��ť�����ֵ�style
    private List<char> vec=new List<char>();//������ʽ�����ĵط�
    string equation = string.Empty;//ƴ�ӳ��ַ�����ʽ�ӻ�����������ʾ��

    //��һ���֣�ϵͳ�ܿز���
    void Start()
    {
        Init();
    }

    //�ڶ����֣������ʼ��GUI
    void OnGUI()
    {
        Init();//��Ĭ�ϵ����ó�ʼ��
        GUI.Box(new Rect(500, 300, 445, 400),"������");//��Χ��x500-945��y300-700
        GUI.Label(new Rect(550, 325, 370, 60), equation, labelStyle);//��ʼ��������ʾ������ı���֮�����equation�е����ݣ��Ϳ��Ը�����ʾ���ı�
        mybutton();//���а�ť������߼�
    }

    //�������֣�Components
    //��ʼ��
    void Init()
    {
        equation = string.Join("", vec);//����ʽ�б��е��ַ�ƴ�ӳ��ַ���

        labelStyle = new GUIStyle(GUI.skin.label);// ����һ���ı����style
        labelStyle.fontSize = 20;// ���������С
        labelStyle.alignment = TextAnchor.MiddleRight;// �����ı����뷽ʽΪ�Ҷ���

        buttonStyle = new GUIStyle(GUI.skin.button);// ����һ����ť��style
        buttonStyle.fontSize = 20;// ���������С
    }
    void mybutton()//��ʼ�����а�ť,�Լ��������Ϊ�߼�
    {
        if (GUI.Button(new Rect(550, 400, 60, 60), "1", buttonStyle))
        {
            vec.Add('1');//����ʽ������û�������ַ�
        }
        if (GUI.Button(new Rect(625, 400, 60, 60), "2", buttonStyle))
        {
            vec.Add('2');//�߼���������ͬ������׸��
        }
        if (GUI.Button(new Rect(700, 400, 60, 60), "3", buttonStyle))
        {
            vec.Add('3');
        }
        if (GUI.Button(new Rect(550, 475, 60, 60), "4", buttonStyle))
        {
            vec.Add('4');
        }
        if (GUI.Button(new Rect(625, 475, 60, 60), "5", buttonStyle))
        {
            vec.Add('5');
        }
        if (GUI.Button(new Rect(700, 475, 60, 60), "6", buttonStyle))
        {
            vec.Add('6');
        }
        if (GUI.Button(new Rect(550, 550, 60, 60), "7", buttonStyle))
        {
            vec.Add('7');
        }
        if (GUI.Button(new Rect(625, 550, 60, 60), "8", buttonStyle))
        {
            vec.Add('8');
        }
        if (GUI.Button(new Rect(700, 550, 60, 60), "9", buttonStyle))
        {
            vec.Add('9');
        }
        if (GUI.Button(new Rect(550, 625, 60, 60), "C", buttonStyle))
        {
            GUI.Label(new Rect(550, 325, 370, 60), "", labelStyle);//����ı���
            vec.Clear();//�����ʽ
        }
        if (GUI.Button(new Rect(625, 625, 60, 60), "0", buttonStyle))
        {
            vec.Add('0');
        }
        if (GUI.Button(new Rect(700, 625, 60, 60), ".", buttonStyle))
        {
            vec.Add('.');
        }
        if (GUI.Button(new Rect(785, 400, 60, 60), "+", buttonStyle))
        {
            vec.Add('+');
        }
        if (GUI.Button(new Rect(860, 400, 60, 60), "-", buttonStyle))
        {
            vec.Add('-');
        }
        if (GUI.Button(new Rect(785, 475, 60, 60), "*", buttonStyle))
        {
            vec.Add('*');
        }
        if (GUI.Button(new Rect(860, 475, 60, 60), "/", buttonStyle))
        {
            vec.Add('/');
        }
        if (GUI.Button(new Rect(785, 550, 60, 60), "(", buttonStyle))
        {
            vec.Add('(');
        }
        if (GUI.Button(new Rect(860, 550, 60, 60), ")", buttonStyle))
        {
            vec.Add(')');
        }
        if (GUI.Button(new Rect(785, 625, 60, 60), "<---", buttonStyle))
        {
            if (vec.Count > 0)//�жϳ��Ȳ�Ϊ��
            {
                vec.RemoveAt(vec.Count-1);//��vecĩβ���ַ��Ƴ�
            }
        }
        if (GUI.Button(new Rect(860, 625, 60, 60), "=", buttonStyle))
        {
            calculating();//������ʽ
        }
    }
    //������
    void calculating()
    {
        var dataTable = new System.Data.DataTable();//����һ�����ڽ������ݴ����datatable��
        equation = Convert.ToString(dataTable.Compute(equation, string.Empty));//ʹ���Դ���Compute�����Դ�����ʽ���м򵥵ļ��㣬�ڶ���������ɸѡ����Ϊ��
        char[] charArray = equation.ToCharArray();//���ַ�����ֳɵ����ַ�
        vec.Clear();//�����ʽ
        foreach (char c in charArray)
        {
            vec.Add((char)c);
        }
    }
}
