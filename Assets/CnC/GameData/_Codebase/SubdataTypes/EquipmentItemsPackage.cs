/// dystop.us | 08.02.2023
using UnityEngine;
using CnC.Legacy;

namespace CnC.GameData
{
    [System.Serializable]
    public class EquipmentItemsPackage : MonoBehaviour
    {
        
        [SerializeField] private EquipmentItemType _itemType;
        [SerializeField] private int _itemId = 0;
        [SerializeField] private int _itemAmount = 1;

        public EquipmentItemType itemType { get { return _itemType; } }
        public int itemId { get { return _itemId; } }
        public int itemAmount { get { return _itemAmount; } }
    }
}