using System;
using UniRx;
using UnityEngine;

namespace Scenes.Battle.Logicks.Services
{
    public readonly struct MouseClick
    {
        private readonly Vector2 _screenClickCoord;

        public Vector2 ScreenClickCoord => _screenClickCoord;

        private readonly Vector2 _worldClickCoord;
        public Vector2 WorldClickCoord => _worldClickCoord;

        public MouseClick(Vector2 screenClickCoord)
        {
            _screenClickCoord = screenClickCoord;
            _worldClickCoord = Camera.current.ScreenToWorldPoint(screenClickCoord);
            Debug.Log(this.ToString());
        }
        
    }
    
    public class InputManager : IUpdateable 
    {
        
       private readonly BehaviorSubject<Vector2?> _rightMouseDown = new BehaviorSubject<Vector2?>(null);

       public IObservable<MouseClick> RightMouseDownObs => _rightMouseDown.AsObservable()
           .Select(coord => coord != null ? new MouseClick(coord.Value) : default);


       private static InputManager _inputManager;
       public static InputManager Instance()
       {
           if (_inputManager != null) return _inputManager;
           _inputManager = new InputManager();
           Debug.Log("Creating new instance of InputService!");

           return _inputManager;
       }
       private InputManager() {}
       
       public void Update(float dt)
       {
           if (Input.GetMouseButtonDown(1))
           {
               _rightMouseDown.OnNext(Input.mousePosition);
           }
           else
           {
               _rightMouseDown.OnNext(null);
           }

           if (Input.GetMouseButtonUp(1))
           {
               _rightMouseDown.OnNext(Input.mousePosition);
           }
           else
           {
               _rightMouseDown.OnNext(null);
           }
           
       }
    }
}