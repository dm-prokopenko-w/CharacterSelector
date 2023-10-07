using Game.Character;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace Game.UI
{
    [RequireComponent(typeof(Button))]
    public class BtnGenerate : MonoBehaviour
    {
        [Inject] private CharacterGenerator _characterGenerator;

        [SerializeField] private Button _button;

        private void Awake()
        {
            _characterGenerator.OnInitBntSpawnRandomCharacter += InitBtn;
        }

        private Button InitBtn()
        {
            _characterGenerator.OnInitBntSpawnRandomCharacter -= InitBtn;
            return _button;
        }
    }
}