﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.InputSystem;
using UnityEngine;

namespace Assets.Scripts.Input
{
    public class InputService : IDisposable
    {
        PlayerInput _playerInput;
        public InputService()
        {
            _playerInput = new PlayerInput();
            _playerInput.Enable();
        }

        public Vector2 GetMovement()
        {
            return _playerInput.ActionsMap.Movement.ReadValue<Vector2>();
        }
        public bool IsShoot()
        {
            return _playerInput.ActionsMap.Shoot.WasPerformedThisFrame();
        }
        public bool IsEscape()
        {
            return _playerInput.ActionsMap.Escape.WasPerformedThisFrame();
        }
        public bool IncHealth()
        {
            return _playerInput.ActionsMap.IncrementHealth.WasPerformedThisFrame();
        }
        public bool DecrHealth()
        {
            return _playerInput.ActionsMap.DecrementHealth.WasPerformedThisFrame();
        }

        public void Dispose()
        {
            _playerInput.Disable();
            _playerInput.Dispose();
        }
    }
}
