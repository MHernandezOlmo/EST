using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    public float _time;
    [SerializeField]
    public int _previousKills = default;

    public enum EnemyTypes {FastEnemy, Enemy2, Enemy3, Enemy4}

    [SerializeField]
    EnemyTypes _enemy;
    public EnemyTypes GetEnemyType()
    {
        return _enemy;
    }
    private void OnDrawGizmos()
    {
        gameObject.name = _enemy.ToString()+ ", "+ _time+"s," + _previousKills +" kills";
    }

}
