using System.Collections.Generic;
using UnityEngine;

public class MobSpawn : MonoBehaviour
{
    [SerializeField] Wave[] _waves;
    [SerializeField] MapController _map;
    [SerializeField] float deltaTime; //время между волнами

    float _time;
    State _spawn = State.notInit;
    int _waveIndex = 0;

    private void Start()
    {
        GameController.StartGameEvent += Init;
    }

    private void Init()
    {
        foreach (var wave in _waves)
        {
            wave.Init();
        }
        _time = 0;
        _spawn = State.spawnWave;
    }

    private void Update()
    {
        if (_spawn == State.waitWave)
        {
            if (_waveIndex > 0)
            {                
                if (_time > deltaTime)
                {
                    _spawn = State.spawnWave;
                    _waveIndex++;
                    _time = 0;
                }
                _time += Time.deltaTime;
            }
        }
        else if (_spawn == State.spawnWave)
        {
            if (_time > _waves[_waveIndex].deltaTime)
            {
                Mob mobPrefab = _waves[_waveIndex].GetMob();
                _time = 0;
                if (mobPrefab != null)
                {
                    Mob mob = Instantiate(mobPrefab, transform);
                    mob.Init(_map);
                }
                else
                {
                    _waveIndex++;
                    if (_waveIndex < _waves.Length)
                    {
                        _spawn = State.waitWave;
                    }
                    else
                    {
                        _spawn = State.notInit;
                    }
                }
            }
            else
            {
                _time += Time.deltaTime;
            }
        }
    }

    public enum State
    {
        notInit,
        waitWave,
        spawnWave
    }

    [System.Serializable]
    public class Wave
    {
        public MobScorer[] mobScorers;
        public float deltaTime; //время спауна между мобами в одной волне

        List<MobScorer> listScores = new List<MobScorer>();

        public void Init()
        {
            foreach (var scorer in mobScorers)
            {
                scorer.count = scorer.maxCount;
            }
            listScores.Clear();
            foreach (var scorer in mobScorers)
            {
                listScores.Add(scorer);
            }
        }

        public Mob GetMob()
        {
            if (listScores.Count == 0)
            {
                return null;
            }

            int random = UnityEngine.Random.Range(0, listScores.Count);
            MobScorer result = listScores[random];
            result.count--;

            if (result.count == 0)
            {
                listScores.Remove(result);
            }

            return result.mob;
        }
    }

    [System.Serializable]
    public class MobScorer
    {
        public Mob mob;
        public int maxCount;

        [HideInInspector]
        public int count;
    }
}

