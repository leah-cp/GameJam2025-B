using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventMenuManager : MonoBehaviour
{
    public GameObject mainMenu;    // �u�}����v�u�X���v���
    public GameObject foodMenu;    // �~����
    public GameObject workMenu;    // �u�@���
    public GameObject parkMenu;    // ������

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
