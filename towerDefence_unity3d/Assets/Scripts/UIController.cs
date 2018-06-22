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
    [SerializeField] Text _health;

    private void Start()
    {
        GameController.StartGameEvent += StartGame;
        GameController.StopGameEvent += StopGame;
        GameController.VictoryEvent += Victory;
        GameController.LoseEvent += Lose;
        HealthController.HealthChangeEvent += HealthChange;
    }
    

    private void OnDestroy()
    {
        GameController.StartGameEvent -= StartGame;
        GameController.StopGameEvent -= StopGame;
        GameController.VictoryEvent -= Victory;
        GameController.LoseEvent -= Lose;
    }

    public void Click(int index)
    {        
        _map.Show(index);
        GameController.StartGame();
    }

    private void StartGame()
    {
        _health.gameObject.SetActive(true);
        _ui.SetActive(false);
        _victory.SetActive(false);
        _lose.SetActive(false);
    }

    void StopGame()
    {
        _ui.SetActive(true);
        _health.gameObject.SetActive(false);
    }

    private void HealthChange()
    {
        _health.text = (Mathf.RoundToInt(HealthController.Health)).ToString();
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
