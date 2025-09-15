using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class RandomEvent
{
    public string eventName;
    public GameObject eventPanel;    // 對應的 Panel
    [Range(0, 100)] public int probability; // 觸發機率 (0~100)
}

[System.Serializable]
public class NoEventReward
{
    [Header("共用設定")]
    public int energyCost = 1;   // 沒觸發事件時消耗精力

    [Header("乞討獎勵")]
    public int minMoney = 1;     // 隨機金錢最小值
    public int maxMoney = 5;     // 隨機金錢最大值

    [Header("散步獎勵")]
    public int minPhysical = 1;  // 隨機體能最小值
    public int maxPhysical = 1;  // 隨機體能最大值
}

public class EventManager : MonoBehaviour
{
    public static EventManager Instance;

    [Header("乞討事件列表")]
    public List<RandomEvent> beggingEvents;

    [Header("散步事件列表")]
    public List<RandomEvent> walkingEvents;

    [Header("沒觸發事件的獎勵 (Inspector 可調整)")]
    public NoEventReward noEventReward;

    [Header("乞討檢測設定")]
    public GameObject parkPage;        // 公園頁面
    public GameObject begNextStory;    // 三個乞討事件完成後的劇情 Panel
    private HashSet<string> triggeredBegEvents = new HashSet<string>();

    private void Awake()
    {
        Instance = this;
    }

    // ---- 按鈕呼叫 ----
    public void TryTriggerBeggingEvent()
    {
        TryTriggerEvent(beggingEvents, true);
    }

    public void TryTriggerWalkingEvent()
    {
        TryTriggerEvent(walkingEvents, false);
    }

    // ---- 共用事件處理 ----
    private void TryTriggerEvent(List<RandomEvent> events, bool isBegging)
    {
        List<RandomEvent> triggered = new List<RandomEvent>();

        foreach (var ev in events)
        {
            int roll = Random.Range(0, 100);
            if (roll < ev.probability)
            {
                triggered.Add(ev);
            }
        }

        if (triggered.Count > 0)
        {
            RandomEvent chosen = triggered[Random.Range(0, triggered.Count)];
            PageManager.Instance.ShowPage(chosen.eventPanel);

            if (isBegging)
            {
                TriggerBegEvent(chosen.eventName);
            }
        }
        else
        {
            StatsManager.Instance.ChangeEnergy(-noEventReward.energyCost);

            if (isBegging)
            {
                int moneyGain = Random.Range(noEventReward.minMoney, noEventReward.maxMoney + 1);
                StatsManager.Instance.ChangeMoney(moneyGain);
                Debug.Log($"[乞討] 沒事件 → +{moneyGain} 金錢, -{noEventReward.energyCost} 精力");
            }
            else
            {
                int physicalGain = Random.Range(noEventReward.minPhysical, noEventReward.maxPhysical + 1);
                StatsManager.Instance.AddPhysical(physicalGain);
                Debug.Log($"[散步] 沒事件 → +{physicalGain} 體能, -{noEventReward.energyCost} 精力");
            }
        }
    }

    // ---- 返回公園 (給 Button 用) ----
    public void BackToPark(GameObject currentPanel)
    {
        if (currentPanel != null)
            currentPanel.SetActive(false);

        if (parkPage != null)
            PageManager.Instance.ShowPage(parkPage);
    }

    // ---- 乞討事件進度追蹤 ----
    private void TriggerBegEvent(string eventName)
    {
        if (!triggeredBegEvents.Contains(eventName))
        {
            triggeredBegEvents.Add(eventName);
        }

        if (triggeredBegEvents.Count >= 3 && begNextStory != null)
        {
            PageManager.Instance.ShowPage(begNextStory);
            Debug.Log("[乞討] 三個事件都完成，進入下一劇情");
        }
    }
}

