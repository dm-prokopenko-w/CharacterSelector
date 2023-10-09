using Core.UI;
using Game.Core;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace Game.UI
{
    [RequireComponent(typeof(Button))]
    public class BtnSceneLoader : MonoBehaviour
    {
        [Inject] private UIController _uiController;

        [SerializeField] private int _sceneIndex;
        [SerializeField] private Button _button;

        private void Awake()
        {
            _uiController.AddUIItem(new UIItem(Constants.SceneLoaderBtn, _button, _sceneIndex));
        }
    }
}