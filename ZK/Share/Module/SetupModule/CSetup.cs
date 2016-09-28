using System;
using System.Collections.Generic;
using System.Text;
using Cn.Youdundianzi.Core.Util;
using Cn.Youdundianzi.Share.Util;

namespace Cn.Youdundianzi.Share.Module.Setup
{
    public class CSetup
    {
        private string _configFilePath;
        public string ConfigFilePath
        {
            get { return _configFilePath; }
        }

        public CSetup(SettingPair set)
        {
            _settings = ModuleConfig.GetSettings(set.ImplementClass, set.FilePath);
            this._configFilePath = set.FilePath;
        }

        private ISettings _settings;
        public ISettings Settings
        {
            get { return _settings; }
        }

        public void SaveSettings()
        {
            ModuleConfig.SaveSettings(_settings, _configFilePath);
        }
    }
}
