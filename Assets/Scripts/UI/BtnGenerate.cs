using Core.UI;
using Game.Core;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace Game.UI
{
    [RequireComponent(typeof(Button))]
    public class BtnGenerate : MonoBehaviour
    {
        [Inject] private UIController _uiController;

        [SerializeField] private Button _button;

        private void Awake()
        {
            _uiController.AddUIItem(new UIItem(Constants.GenerateBtn, _button));
        }
    }
}