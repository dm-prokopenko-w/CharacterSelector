using Game.Character;
using System;
using UnityEngine.UI;
using VContainer;
using VContainer.Unity;

namespace Game.Core
{

    public class GameManager : IStartable
    {
        [Inject] private SceneLoader _sceneLoader;
        [Inject] private CharacterGenerator _characterGenerator;

        public Func<(Button, int)> OnInitBntPlayGame;

        private Button _buttonPlay;

        public void Start()
        {
            if (OnInitBntPlayGame != null)
            {
                (Button, int) parm = OnInitBntPlayGame.Invoke();
                _buttonPlay = parm.Item1;
                _buttonPlay.onClick.AddListener(() => LoadScene(parm.Item2));
            }

            _characterGenerator.OnChangeCharacter += ChangeCharacter;
        }

        private void ChangeCharacter(CharacterSave character)
        {
            if (_buttonPlay == null) return;
            _buttonPlay.interactable = character != null;
        }

        private void LoadScene(int sceneIndex)
        {
            _sceneLoader.LoadScene(sceneIndex);
        }
    }
}
