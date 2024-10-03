using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Windows;

public class calculator : MonoBehaviour
{
    private GUIStyle labelStyle;//文本框显示文字的大小与位置
    private GUIStyle buttonStyle;//按钮上文字的style
    private List<char> vec=new List<char>();//储存算式或结果的地方
    string equation = string.Empty;//拼接成字符串的式子或结果（用于显示）

    //第一部分：系统总控部分
    void Start()
    {
        Init();
    }

    //第二部分：界面初始化GUI
    void OnGUI()
    {
        Init();//将默认的配置初始化
        GUI.Box(new Rect(500, 300, 445, 400),"计算器");//范围是x500-945，y300-700
        GUI.Label(new Rect(550, 325, 370, 60), equation, labelStyle);//初始化用于显示计算的文本框，之后更改equation中的内容，就可以更改显示的文本
        mybutton();//进行按钮的相关逻辑
    }

    //第三部分：Components
    //初始化
    void Init()
    {
        equation = string.Join("", vec);//将算式列表中的字符拼接成字符串

        labelStyle = new GUIStyle(GUI.skin.label);// 创建一个文本框的style
        labelStyle.fontSize = 20;// 设置字体大小
        labelStyle.alignment = TextAnchor.MiddleRight;// 设置文本对齐方式为右对齐

        buttonStyle = new GUIStyle(GUI.skin.button);// 创建一个按钮的style
        buttonStyle.fontSize = 20;// 设置字体大小
    }
    void mybutton()//初始化所有按钮,以及背后的行为逻辑
    {
        if (GUI.Button(new Rect(550, 400, 60, 60), "1", buttonStyle))
        {
            vec.Add('1');//像算式中添加用户输入的字符
        }
        if (GUI.Button(new Rect(625, 400, 60, 60), "2", buttonStyle))
        {
            vec.Add('2');//逻辑与上面相同，不再赘述
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
            GUI.Label(new Rect(550, 325, 370, 60), "", labelStyle);//清空文本框
            vec.Clear();//清空算式
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
            if (vec.Count > 0)//判断长度不为零
            {
                vec.RemoveAt(vec.Count-1);//将vec末尾的字符移除
            }
        }
        if (GUI.Button(new Rect(860, 625, 60, 60), "=", buttonStyle))
        {
            calculating();//计算算式
        }
    }
    //计算结果
    void calculating()
    {
        var dataTable = new System.Data.DataTable();//创建一个用于进行数据处理的datatable类
        equation = Convert.ToString(dataTable.Compute(equation, string.Empty));//使用自带的Compute函数对传入表达式进行简单的计算，第二个条件是筛选条件为空
        char[] charArray = equation.ToCharArray();//将字符串拆分成单个字符
        vec.Clear();//清空算式
        foreach (char c in charArray)
        {
            vec.Add((char)c);
        }
    }
}
