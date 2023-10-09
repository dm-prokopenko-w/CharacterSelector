using Core.UI;
using Game.Character;
using UnityEngine.UI;
using VContainer;
using VContainer.Unity;

namespace Game.Core
{
    public class GameManager : IStartable
    {
        [Inject] private SceneLoader _sceneLoader;
        [Inject] private CharacterGenerator _characterGenerator;
        [Inject] private UIController _uiController;

        private Button _buttonPlay;

        public void Start()
        {
            var item = _uiController.GetUIItemById(Constants.SceneLoaderBtn);
            if (item != null)
            {
                _buttonPlay = item.Btn;
                item.Btn.onClick.AddListener(() => LoadScene(item.Num));
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