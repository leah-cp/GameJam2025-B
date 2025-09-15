using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsManager : MonoBehaviour
{
    public static StatsManager Instance;

    public int currentDay;
    public int timeSlot;
    public int maxDays;
    public int stamina;
    public int money;
    public int physical;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        // Update logic here
    }

    public void NextTimeSlot()
    {
        // Logic for advancing time slot
    }

    public void UseStamina(int amount)
    {
        stamina -= amount;
    }

    public void AddStamina(int amount)
    {
        stamina += amount;
    }

    public void AddMoney(int amount)
    {
        money += amount;
    }

    public void UseMoney(int amount)
    {
        money -= amount;
    }

    public void AddPhysical(int amount)
    {
        physical += amount;
    }

    public void ChangeEnergy(int amount)
    {
        stamina += amount;
    }

    // Fix: Add the missing ChangeMoney method
    public void ChangeMoney(int amount)
    {
        money += amount;
    }

    private void CheckGameOver()
    {
        // Logic for checking game over conditions
    }
}
