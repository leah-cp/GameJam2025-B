using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsUI : MonoBehaviour
{
    [Header("UI ¤¸¥ó")]
    public Text dayText;
    public Text timeSlotText;
    public Text staminaText;
    public Text moneyText;
    public Text physicalText;

    private StatsManager stats;

    void Start()
    {
        stats = StatsManager.Instance;
    }

    void Update()
    {
        if (stats == null) return;

        dayText.text = $"Day: {stats.currentDay}";
        timeSlotText.text = $"Time: {stats.timeSlot}/5";
        staminaText.text = $"Stamina: {stats.stamina}";
        moneyText.text = $"Money: {stats.money}";
        physicalText.text = $"Physical: {stats.physical}";
    }
}
