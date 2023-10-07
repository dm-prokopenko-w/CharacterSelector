using Game.Core;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace Game.UI
{
    [RequireComponent(typeof(Button))]
    public class BtnSceneLoader : MonoBehaviour
    {
        [Inject] private GameManager _gameManager;

        [SerializeField] private int _sceneIndex;
        [SerializeField] private Button _button;

        private void Awake()
        {
            _gameManager.OnInitBntPlayGame += InitBtn;
        }

        private (Button, int) InitBtn()
        {
            _gameManager.OnInitBntPlayGame -= InitBtn;
            return (_button, _sceneIndex);
        }
    }
}