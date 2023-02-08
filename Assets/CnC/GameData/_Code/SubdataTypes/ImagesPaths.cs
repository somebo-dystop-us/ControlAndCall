/// dystop.us | 08.02.2023
using System;

using UnityEngine;

namespace CnC.GameData
{
    [Serializable]
    public class ImagesPaths
    {
        #region Public accessors - for a legacy purposes mostly

        public string imagePath { get => _imagePath; }
        public string logoBrandImagePath { get => _logoBrandImagePath; }
        public string[] imageRendersPath { get => _imageRendersPath; }

        #endregion

        #region Inspector / Private fields 

        [SerializeField] private string _imagePath = ""; //  "Icons/Lines/";
        [SerializeField] private string _logoBrandImagePath = "";
        [SerializeField] private string[] _imageRendersPath;

        #endregion

        #region Constructors

        public ImagesPaths(string imagePath, string logoBrandImagePath, string[] imageRendersPath)
        {
            _imagePath = imagePath;
            _logoBrandImagePath = logoBrandImagePath;
            _imageRendersPath = imageRendersPath;
        }

        #endregion

        #region Public methods - mostly legacy ones 

        public Sprite GetIconImage()
        {
            return Resources.Load<Sprite>(GameDataUtils.ResourcesIcons + imagePath);
        }

        public Sprite GetLogoBrandImage()
        {
            return Resources.Load<Sprite>(GameDataUtils.ResourcesIcons + GameDataUtils.ResourcesBrands + logoBrandImagePath);
        }

        /// <summary>
        /// //pobiera image renderu
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Sprite GetRenderImage(int index)
        {
            if (imageRendersPath[index] == null) return null;

            return Resources.Load<Sprite>(GameDataUtils.ResourcesRenders + GameDataUtils.ResourcesLines + imageRendersPath[index]);
        }

        #endregion
    }
}
