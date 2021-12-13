using System;
using System.Diagnostics;
using Scenes.Battle.Logicks.Behaviours;
using Scenes.Battle.Logicks.Services;
using UniRx;
using UniRx.Operators;
using UnityEngine;

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

        private DestinationManager()
        {
        }

        private IObservable<Vector2> currentDestination = Observable.CombineLatest(SelectionManager.Instance().SelectionObs,
            InputManager.Instance().RightMouseDownObs,
            (s, b) =>
            {
                
            }
            );
        }
    }
