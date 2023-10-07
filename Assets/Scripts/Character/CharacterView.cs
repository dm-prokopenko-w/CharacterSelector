using VContainer;
using UnityEngine;

namespace Game.Character
{
    public class CharacterView : MonoBehaviour
    {
        [Inject] private CharacterGenerator _characterGenerator;

        private void Awake()
        {
            _characterGenerator.OnInitContainer += InitContainer;
        }

        private Transform InitContainer()
        {
            _characterGenerator.OnInitContainer -= InitContainer;
            return transform;
        }
    }
}