using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Core.UI
{
    public class UIController
    {
        private List<UIItem> _uiItem = new List<UIItem>();

        public void AddUIItem(UIItem item)
        {
            _uiItem.Add(item);
        }

        public UIItem GetUIItemById(string id)
        {
            var item = _uiItem.Find(x => x.Id.Equals(id));
            if (item == null) return null;
            return item;
        }
    }

    public class UIItem
    {
        public string Id;
        public Button Btn;
        public Transform Tr;
        public int Num;

        public UIItem(string id, Button btn)
        {
            Id = id;
            Btn = btn;
        }

        public UIItem(string id, Button btn, int num)
        {
            Id = id;
            Btn = btn;
            Num = num;
        }

        public UIItem(string id, Transform tr)
        {
            Id = id;
            Tr = tr;
        }
    }
}