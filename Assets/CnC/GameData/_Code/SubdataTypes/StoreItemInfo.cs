/// dystop.us | 08.02.2023

using System;

using UnityEngine;

namespace CnC.GameData
{
    [Serializable]
    public class StoreItemInfo 
    {
        #region Private & inspector fields

        [SerializeField] private bool _isComingSooon = false;
        [SerializeField] private bool _isInShop = true;
        [SerializeField] private bool _isNew = false;

        [SerializeField] private int _priceNormal = 0;
        [SerializeField] private int _saleOff = 0;

        [SerializeField] private float _amount = 1;

        #endregion

        #region Public accesors - mostly for legacy purposes

        public bool IsComingSoon { get { return _isComingSooon; } }

        public bool IsInShop { get { return _isInShop; } }
        public bool IsNew { get { return _isNew; } }

        public int PriceNormal { get { return _priceNormal; } }
        public int SaleOff { get { return _saleOff; } }

        public float Amount { get { return _amount; } set { _amount = value; } }

        #endregion

        #region Constructors 

        /// <summary>
        /// Constructor fully for legacy/dev purposes
        /// </summary>
        /// <param name="isInShop"></param>
        /// <param name="isNew"></param>
        /// <param name="priceNormal"></param>
        /// <param name="saleOff"></param>
        /// <param name="amount"></param>
        public StoreItemInfo(bool isInShop, bool isNew, int priceNormal, int saleOff, float amount, bool isComingSooon = false)
        {
            _isInShop = isInShop;
            _isNew = isNew;
            _priceNormal = priceNormal;
            _saleOff = saleOff;
            _amount = amount;
            _isComingSooon = isComingSooon;
        }

        #endregion

        #region Public methods - legacy

        public float GetPrice()
        {
            float price = (PriceNormal - (PriceNormal * (SaleOff * 0.01f)));

            /*
            //Efekt Skils
            if (GameManager.Instance._playerData.PlayerHasSkill(GameManager.Skills.merchant_10p)) 
                price -= (price * 0.1f);
            else
                if (GameManager.Instance._playerData.PlayerHasSkill(GameManager.Skills.merchant_5p)) 
                    price -= (price * 0.05f);

            price = Mathf.Round(price * 100f) / 100f; //zaokraglij do 2nd 
            */
            return price;
        }

        #endregion
    }
}
