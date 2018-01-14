using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealsController : MonoBehaviour
{
    public int Heals { get; private set; }
    public UIController UIController;

    [SerializeField]
    private int _maxHeals;

    private GameManager _gameManager;

    public void Start()
    {
        Heals = _maxHeals;
        _gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        UIController.ShowHeals(Heals);
    }

    public void AddHeals(int heals)
    {
        Heals += heals;

        if (Heals > _maxHeals)
        {
            Heals = _maxHeals;
        }

        UIController.ShowHeals(Heals);
    }

    public void TakeDamage(int heals)
    {
        Heals -= heals;

        if (Heals <= 0)
        {
            Heals = 0;
            _gameManager.EndGame();
        }

        UIController.ShowHeals(Heals);
    }
}
