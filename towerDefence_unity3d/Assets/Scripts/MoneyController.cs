using System;
using UnityEngine;

public class MoneyController : MonoBehaviour
{
    [SerializeField] float _maxMoney;

    public static float Money { get; private set; }
    public static Action MoneyChangeEvent;

    private void Start()
    {
        GameController.StartGameEvent += StartGame;
        Mob.RewardEvent += Reward;
    }    

    private void OnDestroy()
    {
        GameController.StartGameEvent -= StartGame;
        Mob.DamageEvent -= Reward;
    }

    private void StartGame()
    {
        Money = _maxMoney;
        MoneyChangeEvent?.Invoke();
    }

    public static void Reward(float obj)
    {
        Money += obj;
        MoneyChangeEvent?.Invoke();
    }
}
