using System.Collections;
using System.Collections.Generic;
using Framework.CheckPoints;
using Oculus.Interaction;
using Unity.VisualScripting;
using UnityEngine;

public class DublicatesMan : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> _activatee;
    private CheckPoint _myCheck;
    private PointableUnityEventWrapper _grabEvents;
    void OnEnable()
    {
        _myCheck = GetComponent<CheckPoint>();
        _grabEvents = GetComponentInChildren<PointableUnityEventWrapper>();
    }
    void Start()
    {
        _grabEvents.WhenSelect.AddListener((x) => OnSelect());
        _grabEvents.WhenUnselect.AddListener((x) => OnLetGo());
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
}
