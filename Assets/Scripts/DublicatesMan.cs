using System.Collections.Generic;
using Framework;
using Framework.CheckPoints;
using FrameworkTest;
using Oculus.Interaction;
using UnityEngine;

public class DublicatesMan : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> _activatee;
    private CheckPoint _myCheck;
    private PointableUnityEventWrapper _grabEvents;
    private SnapObject _snapCode;
    void OnEnable()
    {
        _myCheck = GetComponent<CheckPoint>();
        _grabEvents = GetComponentInChildren<PointableUnityEventWrapper>();
        //TODO: rework this code
        foreach (var go in _activatee)
        {
            _snapCode = go.GetComponent<SnapObject>();
        }
    }
    void Start()
    {
        _grabEvents.WhenSelect.AddListener((x) => OnSelect());
        _grabEvents.WhenUnselect.AddListener((x) => OnLetGo());
        _snapCode.OnSnapped.AddListener(OnSnapped);

    }

    private void OnSelect()
    {
        if (!_myCheck.IsChecked && _activatee != null)
        {
            foreach (var go in _activatee)
                go.SetActive(true);
        }
    }
    private void OnLetGo()
    {
        if (!_myCheck.IsChecked && _activatee != null)
        {
            foreach (var go in _activatee)
                go.SetActive(true);
        }
    }
    private void OnSnapped()
    {
        _myCheck.MarkAsChecked();
    }
}
