using Scenes.Battle.Logicks.Managers;
using Scenes.Battle.Logicks.Services;
using UniRx;
using UnityEngine;

namespace Scenes.Battle.Logicks.Behaviours
{
    public class SelectionBehaviour : MonoBehaviour
    {
        // Start is called before the first frame update
        private SpriteRenderer _spriteRenderer;
        void Start()
        {
            _spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
            SelectionManager.Instance().SelectionObs
                .SelectMany(s => s)
                .Select(s => s == this)
                .Subscribe( isSelected => _spriteRenderer.enabled = isSelected)
                .AddTo(this);

            InputManager.Instance().RightMouseDownObs.Subscribe(isPressed => Debug.Log(isPressed.ToString()));
        }

        private void OnMouseDown()
        {
            Debug.Log(this.GetInstanceID());
            SelectionManager.Instance().Select(this);
        }

    }
}
