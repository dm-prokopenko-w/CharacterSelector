using VContainer;
using UnityEngine;
using Core.UI;
using Game.Core;

namespace Game.Character
{
    public class CharacterView : MonoBehaviour
    {
        [Inject] private UIController _uiController;

        private void Awake()
        {
            _uiController.AddUIItem(new UIItem(Constants.CharacterViewTrans, transform));
        }
    }
}