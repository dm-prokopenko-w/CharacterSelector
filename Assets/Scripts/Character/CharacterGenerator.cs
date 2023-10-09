using Core.UI;
using Game.Configs;
using Game.Core;
using System;
using System.Collections.Generic;
using UnityEngine;
using VContainer;
using VContainer.Unity;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

namespace Game.Character
{
    public class CharacterGenerator : IStartable
    {
        [Inject] private ConfigsLoader _configsLoader = null;
        [Inject] private SaveManager _saveManager;
        [Inject] private UIController _uiController;

        public Action<CharacterSave> OnChangeCharacter;

        private List<CharacterItemPool> _pools = new List<CharacterItemPool>();
        private int _countCharacter;
        private Transform _container;
        private CharacterItemPool _currentItem;
        private CharacterSave _saveItem;
        private CharacterConfig _data;

        public async void Start()
        {
            _data = await _configsLoader.LoadConfig(Constants.CharacterData) as CharacterConfig;

            _countCharacter = _data.Characters.Count;
            if (_countCharacter <= 0)
            {
                Debug.LogError("Add character variations!");
                return;
            }

            InitUI();


            var item = _saveManager.Load<CharacterSave>(Constants.CharacterKey);
            string id = item == null ? _data.Characters[0].Id : item.Id;

            SpawnCharacter(id, _container.position, _container.rotation);
        }

        public void SpawnRandomCharacter()
        {
            if (_countCharacter <= 0)
            {
                Debug.LogError("Add character variations!");
                return;
            }

            List<string> _ids = new List<string>();
            foreach (var item in _data.Characters)
            {
                _ids.Add(item.Id);
            }

            if (_currentItem != null)
            {
                Despawn();
                _ids.Remove(_currentItem.Id);
            }

            int numCharacter = Random.Range(0, _ids.Count);
            SpawnCharacter(_ids[numCharacter], _container.position, _container.rotation);
        }

        public void Despawn()
        {
            OnChangeCharacter?.Invoke(null);
            _saveManager.Delete(Constants.CharacterKey);
            _currentItem.Prefab.SetActive(false);
            _currentItem.Prefab.transform.SetParent(_container);
        }

        private void InitUI()
        {
            var generateBtn = _uiController.GetUIItemById(Constants.GenerateBtn);
            if (generateBtn != null)
            {
                generateBtn.Btn.onClick.AddListener(SpawnRandomCharacter);
            }

            var clearCharacterViewBtn = _uiController.GetUIItemById(Constants.ClearCharacterViewBtn);
            if (clearCharacterViewBtn != null)
            {
                clearCharacterViewBtn.Btn.onClick.AddListener(Despawn);
            }

            var container = _uiController.GetUIItemById(Constants.CharacterViewTrans);
            if (container != null)
            {
                _container = container.Tr;
            }
        }

        private void SpawnCharacter(string id, Vector3 pos, Quaternion rot)
        {
            _currentItem = _pools.Find(x => x.Id.Equals(id));

            if (_currentItem == null)
            {
                _currentItem = IsInitCharacter(id);
                if (_currentItem == null)
                {
                    SpawnCharacter(_data.Characters[0].Id, _container.position, _container.rotation);
                    return;
                }
            }
            else
            {
                Despawn();
            }

            Debug.Log("Spawn character with id: " + _currentItem.Id);

            _saveItem = new CharacterSave()
            {
                Id = id,
            };
            OnChangeCharacter?.Invoke(_saveItem);

            _saveManager.Save(Constants.CharacterKey, _saveItem);
            _currentItem.Prefab.SetActive(true);

            _currentItem.Prefab.transform.position = pos;
            _currentItem.Prefab.transform.rotation = rot;
        }

        private CharacterItemPool IsInitCharacter(string id)
        {
            var item = _pools.Find(x => x.Id.Equals(id));
            if (item == null)
            {
                var character = _data.Characters.Find(x => x.Id.Equals(id));
                if (character == null) return null;

                GameObject obj = Object.Instantiate(character.Prefab, _container);
                obj.name = id;
                obj.SetActive(false);
                var ch = new CharacterItemPool(id, obj);
                _pools.Add(ch);
                return ch;
            }

            return null;
        }
    }
}