using UnityEngine;
using UnityEngine.UI;


public class EventAction : MonoBehaviour
{
    [Header("效果數值")]
    public int moneyChange;
    public int staminaChange;
    public int physicalChange;

    [Header("UI")]
    public Button actionButton;
    public Text buttonText;

    private void Start()
    {
        if (actionButton != null)
        {
            actionButton.onClick.AddListener(ApplyAction);
        }
    }

    private void ApplyAction()
    {
        StatsManager stats = StatsManager.Instance;

        if (moneyChange != 0)
        {
            if (moneyChange > 0) stats.AddMoney(moneyChange);
            else stats.UseMoney(-moneyChange);
        }

        if (staminaChange != 0)
        {
            if (staminaChange > 0) stats.AddStamina(staminaChange);
            else stats.UseStamina(-staminaChange);
        }

        if (physicalChange != 0)
        {
            stats.AddPhysical(physicalChange);
        }

        stats.NextTimeSlot(); // 每次行動結束推進時間
    }
}
