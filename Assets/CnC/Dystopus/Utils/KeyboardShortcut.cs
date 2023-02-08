using System;
using UnityEngine;

namespace _dystopus.Utils
{
    [Serializable]
    public class KeyboardShortcut
    {
        [SerializeField]
        private string _name;

        [SerializeField]
        private KeyCode[] _keyCodes;

        public KeyCode[] KeyCodes { get => _keyCodes; }

        public KeyboardShortcut(params KeyCode[] keyCodes)
        {
            _keyCodes = keyCodes;
            _name = ToString();
        }

        public override string ToString()
        {
            switch (_keyCodes.Length)
            {
                case 1:
                    return ("[" + _keyCodes[0] + "]");
                case 2:
                    return ("[" + _keyCodes[0] + "] + [" + _keyCodes[1] + "]");
                case 3:
                    return ("[" + _keyCodes[0] + "] + [" + _keyCodes[1] + "] + [" + _keyCodes[2] + "]");

            }
            return base.ToString();
        }
    }
}