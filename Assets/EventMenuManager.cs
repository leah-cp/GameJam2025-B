using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventMenuManager : MonoBehaviour
{
    public GameObject mainMenu;    // 「開手機」「出門」選單
    public GameObject foodMenu;    // 外賣選單
    public GameObject workMenu;    // 工作選單
    public GameObject parkMenu;    // 公園選單

    public void OpenFoodMenu()
    {
        mainMenu.SetActive(false);
        foodMenu.SetActive(true);
    }

    public void OpenWorkMenu()
    {
        mainMenu.SetActive(false);
        workMenu.SetActive(true);
    }

    public void OpenParkMenu()
    {
        mainMenu.SetActive(false);
        parkMenu.SetActive(true);
    }

    public void BackToMain()
    {
        foodMenu.SetActive(false);
        workMenu.SetActive(false);
        parkMenu.SetActive(false);
        mainMenu.SetActive(true);
    }
}
