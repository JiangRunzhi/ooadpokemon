using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataControler : MonoBehaviour
{
    private Button skillABtn, skillBBtn, skillCBtn, skillDBtn, skillA1Btn, skillB1Btn, skillC1Btn, skillD1Btn;
    Transform root;

    void Start ()
    {
        //获得脚本挂的Transform
        root = this.transform;
        //获取场景中按钮的引用
        skillABtn = root.Find("A").GetComponent<Button>();
        skillBBtn = root.Find("B").GetComponent<Button>();
        skillCBtn = root.Find("C").GetComponent<Button>();
        skillDBtn = root.Find("D").GetComponent<Button>();
        skillA1Btn = root.Find("A1").GetComponent<Button>();
        skillB1Btn = root.Find("B1").GetComponent<Button>();
        skillC1Btn = root.Find("C1").GetComponent<Button>();
        skillD1Btn = root.Find("D1").GetComponent<Button>();
        //注册点击事件
        skillABtn.onClick.AddListener(OnSkillAClick);
        skillBBtn.onClick.AddListener(OnSkillBClick);
        skillCBtn.onClick.AddListener(OnSkillCClick);
        skillDBtn.onClick.AddListener(OnSkillDClick);
        skillA1Btn.onClick.AddListener(OnSkillA1Click);
        skillB1Btn.onClick.AddListener(OnSkillB1Click);
        skillC1Btn.onClick.AddListener(OnSkillC1Click);
        skillD1Btn.onClick.AddListener(OnSkillD1Click);
    }

    void OnSkillAClick()
    {
        Program.button0();
        Program.engine();
    }
    void OnSkillBClick()
    {
        Program.button1();
        Program.engine();
    }
    void OnSkillCClick()
    {
        Program.button2();
        Program.engine();
    }
    void OnSkillDClick()
    {
        Program.button3();
        Program.engine();
    }
    void OnSkillA1Click()
    {
        Program.button4();
        Program.engine();
    }
    void OnSkillB1Click()
    {
        Program.button5();
        Program.engine();
    }
    void OnSkillC1Click()
    {
        Program.button6();
        Program.engine();
    }
    void OnSkillD1Click()
    {
        Program.button7();
        Program.engine();
    }
}
