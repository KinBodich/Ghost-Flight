using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class MoneySystem : MonoBehaviour, IDataPersistence
{
    public static MoneySystem Instance { get; private set; }
    private TargetDestroy _target;
    public int MoneyAmount { get; set; }

    public event Action OnMoneyAmountChange;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        TimeMoneyIncrease();
    }

    private void Update()
    {
        if (!_target)
            FindTarget();
    }

    private void FindTarget()
    {
        try
        {
            _target = FindObjectOfType<TargetDestroy>();
            _target.OnTargetDestroy += OnTargetDestroyMoneyIncrease;
        }
        catch (NullReferenceException ex)
        {
            Debug.Log(ex);
        }
    }

    private void OnTargetDestroyMoneyIncrease()
    {
        MoneyAmount += 100;
        Debug.Log(MoneyAmount);
        OnMoneyAmountChange?.Invoke();
    }

    private async void TimeMoneyIncrease()
    {
        while (true)
        {
            await Task.Delay(10000);
            MoneyAmount++;
            OnMoneyAmountChange?.Invoke();
        }
    }

    public void DecreaseMoneyAmount(int price)
    {
        MoneyAmount -= price;
    }

    public void LoadData(GameData data)
    {
        MoneyAmount = data.MoneyAmount;
    }

    public void SaveData(GameData data)
    {
        data.MoneyAmount = MoneyAmount;
    }
}
