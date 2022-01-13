using System;
using System.Diagnostics;
using JetBrains.Annotations;
using Scenes.Battle.Logicks.Behaviours;
using Scenes.Battle.Logicks.Services;
using UniRx;
using UniRx.Operators;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace Scenes.Battle.Logicks.Managers
{
    public class DestinationManager
    {
        private static DestinationManager _instance;


        public static DestinationManager Instance()
        {
            if (_instance != null) return _instance;

            _instance = new DestinationManager();
            return _instance;
        }

        private DestinationManager() {}

        [CanBeNull]
        public IObservable<Vector2?> CurrentDestination { get; } = 
            SelectionManager.Instance().SelectionObs.CombineLatest<SelectionBehaviour[], MouseClick, Vector2?>(InputManager.Instance().RightMouseDownObs,
            (s, b) =>
            {
                Debug.Log(b.ToString());
                return s.Length == 0 ? (Vector2?)null : b.WorldClickCoord;
            });
    }
    
    }
