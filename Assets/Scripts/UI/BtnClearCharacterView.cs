using Game.Character;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace Game.UI
{
    [RequireComponent(typeof(Button))]
    public class BtnClearCharacterView : MonoBehaviour
    {
        [Inject] private CharacterGenerator _characterGenerator;

        [SerializeField] private Button _button;

        private void Awake()
        {
            _characterGenerator.OnInitBntDespawnCharacter += InitBtn;
        }

        private Button InitBtn()
        {
            _characterGenerator.OnInitBntDespawnCharacter -= InitBtn;
            return _button;
        }
    }
}