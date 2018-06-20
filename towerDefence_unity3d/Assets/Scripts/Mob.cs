using UnityEngine;

public class Mob : MonoBehaviour
{
    public static System.Action<float>  RewardEvent; //моб мертв, игрок должен поулчить награду
    public static System.Action<float>  DamageEvent; //моб дошел до конца пути, игрок должен получить урон
    public static System.Action         DestroyEvent;

    [SerializeField] float _maxHp;
    [SerializeField] float _damage;
    [SerializeField] float _reward;

    float _time = 0;
    float _hp;
    MapController _map;

    public void Init(MapController map)
    {
        _map = map;
        _hp = _maxHp;
        GameController.StopGameEvent += DestroyObj;
    }

    private void DestroyObj()
    {
        Destroy(gameObject);
    }

    void Update()
    {
        if (_hp > 0)
        {
            Vector2? pos = _map.GetPosition(_time);
            if (pos.HasValue)
            {
                transform.localPosition = new Vector3(pos.Value.x, 0, pos.Value.y);
                _time += Time.deltaTime;
            }
            else
            {
                DamageEvent?.Invoke(_damage);
                DestroyObj();
            }            
        }
        else
        {
            RewardEvent?.Invoke(_reward);
            DestroyObj();
        }
    }

    private void OnDestroy()
    {
        GameController.StopGameEvent -= DestroyObj;
        DestroyEvent?.Invoke();
    }
}
