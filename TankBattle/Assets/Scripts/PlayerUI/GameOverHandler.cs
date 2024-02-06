using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverHandler : MonoBehaviour
{
    [SerializeField] GameObject GameOverPanel;
    private void OnEnable()
    {
        GameEvents.OnGameOverEvent += OnGameOver;
    }
    private void OnDisable()
    {
        GameEvents.OnGameOverEvent -= OnGameOver;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnGameOver()
    {
        GameOverPanel.SetActive(true);
    }
    public void OnExit()
    {
        Application.Quit();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
