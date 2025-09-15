using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageManager : MonoBehaviour
{
    public static PageManager Instance;

    [Header("頁面物件")]
    public GameObject mainPage;     // 首頁：開手機 / 出門
    public GameObject phonePage;    // 開手機選單
    public GameObject foodPage;     // 外賣選單
    public GameObject goOutPage;    // 出門選單
    public GameObject workPage;     // 工作選單
    public GameObject parkPage;     // 公園選單

    private GameObject currentPage;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        ShowPage(mainPage); // 遊戲開始顯示首頁
    }

    // ��ܬY�ӭ���
    public void ShowPage(GameObject page)
    {
        // ���éҦ�����
        mainPage.SetActive(false);
        phonePage.SetActive(false);
        foodPage.SetActive(false);
        goOutPage.SetActive(false);
        workPage.SetActive(false);
        parkPage.SetActive(false);
        
      
        // ��ܥؼЭ���
        page.SetActive(true);
        currentPage = page;
    }

    // ��^����
    public void BackToMain()
    {
        currentPage.SetActive(false);
        ShowPage(mainPage);
    }

    // ��^�W�@�h�]�ھڥثe�����P�_�^
    public void Back()
    {
        if (currentPage == phonePage || currentPage == goOutPage)
        {
            ShowPage(mainPage);
        }
        else if (currentPage == foodPage)
        {
            ShowPage(phonePage);
        }
        else if (currentPage == workPage || currentPage == parkPage)
        {
            ShowPage(goOutPage);
        }
    }
}
