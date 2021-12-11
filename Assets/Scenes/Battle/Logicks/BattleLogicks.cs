using Scenes.Battle.Logicks.Managers;
using Scenes.Battle.Logicks.Services;
using UnityEngine;

public class BattleLogicks : MonoBehaviour
{
    private InputManager _inputManager = InputManager.Instance();
    private SelectionManager _selectionManager = SelectionManager.Instance();

    // Update is called once per frame
    void Update()
    {
       _inputManager.Update(Time.deltaTime); 
    }
}
