using System.Collections.Generic;
using Oculus.Interaction;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    [SerializeField]
    private List<RayInteractor> _hands;
    [SerializeField]
    private Transform _player;

    private PointableUnityEventWrapper _evntWrapper;
    void Start()
    {
        _evntWrapper=GetComponent<PointableUnityEventWrapper>();
        _evntWrapper?.WhenSelect.AddListener((x)=>Teleport());
    }

    public void Teleport()
    {
        foreach(var hand in _hands)
        {
            if(hand.CollisionInfo.HasValue)
            {
                _player.position=hand.CollisionInfo.Value.Point;
            }
        }
    }
}
