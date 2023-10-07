using Game.Configs;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Character
{
    [CreateAssetMenu(fileName = "CharacterData", menuName = "Data/CharacterData", order = 0)]
    public class CharacterConfig : Config
    {
        public List<CharacterData> Characters;

    }

    [Serializable]
    public class CharacterData
    {
        public string Id;
        public GameObject Prefab;
    }
}