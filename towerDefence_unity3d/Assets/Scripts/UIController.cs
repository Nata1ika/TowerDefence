using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using System;

public class UIController : MonoBehaviour
{
    [SerializeField] MapController _map;
    [SerializeField] GameObject _ui;
    [SerializeField] GameObject _victory;
    [SerializeField] GameObject _lose;
    [SerializeField] GameObject _gameUI;
    [SerializeField] Text _health;
    [SerializeField] Text _money;

    private void Start()
    {
        GameController.StartGameEvent += StartGame;
        GameController.StopGameEvent += StopGame;
        GameController.VictoryEvent += Victory;
        GameController.LoseEvent += Lose;
        HealthController.HealthChangeEvent += HealthChange;
        MoneyController.MoneyChangeEvent += MoneyChange;
    }    

    private void OnDestroy()
    {
        GameController.StartGameEvent -= StartGame;
        GameController.StopGameEvent -= StopGame;
        GameController.VictoryEvent -= Victory;
        GameController.LoseEvent -= Lose;
        HealthController.HealthChangeEvent -= HealthChange;
        MoneyController.MoneyChangeEvent -= MoneyChange;
    }

    public void Click(int index)
    {        
        _map.Show(index);
        GameController.StartGame();
    }

    private void StartGame()
    {
        _gameUI.SetActive(true);
        _ui.SetActive(false);
        _victory.SetActive(false);
        _lose.SetActive(false);
    }

    void StopGame()
    {
        _ui.SetActive(true);
        _gameUI.SetActive(false);
    }

    private void HealthChange()
    {
        _health.text = string.Format("Health: {0}", Mathf.RoundToInt(HealthController.Health));
    }

    private void MoneyChange()
    {
        _money.text = string.Format("Money: {0}", Mathf.RoundToInt(MoneyController.Money));
    }

    void Victory()
    {
        _victory.SetActive(true);
    }

    void Lose()
    {
        _lose.SetActive(true);
    }
}
