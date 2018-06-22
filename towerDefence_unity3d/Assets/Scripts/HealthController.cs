using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    [SerializeField] float _maxHealth;

    public static float Health { get; private set; }
    public static Action HealthChangeEvent;

    private void Start()
    {
        GameController.StartGameEvent += StartGame;
        Mob.DamageEvent += Damage;
    }

    private void OnDestroy()
    {
        GameController.StartGameEvent -= StartGame;
        Mob.DamageEvent -= Damage;
    }

    void Damage(float obj)
    {
        Health -= obj;
        if (Health <= 0)
        {
            Health = 0;
            GameController.Lose();
        }
        HealthChangeEvent?.Invoke();
    }

    void StartGame()
    {
        Health = _maxHealth;
        HealthChangeEvent?.Invoke();
    }
}
