using Assets.Scripts.Input;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class MenuPanelHandler : MonoBehaviour
{
    [SerializeField] GameObject MenuPanel;
    InputService InputService;
    [Inject]
    public void Construtct(InputService inputService)
    {
        InputService = inputService;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(InputService.IsEscape())
        {
            if(MenuPanel.activeSelf)
            {
                MenuPanel.SetActive(false);
            }
            else
            {
                MenuPanel.SetActive(true);
            }
        }
    }

    public void Continue()
    {
        MenuPanel.SetActive(false);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
