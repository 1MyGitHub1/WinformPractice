using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using All_Test.Serials;
using System.Windows;

namespace All_Test
{
    public class GlobalInfo
    {
        public static GlobalInfo Instance
        {
            get { return _instance; }
        }
        private static readonly GlobalInfo _instance = new GlobalInfo();

        ///<summary>
        ///自动进样器通信接口
        ///</summary>
        public SamplerSerials Totalab_LSerials
        {
            get => _totalabSerials;
            set
            {
                this._totalabSerials = value;
            }
        }
        private SamplerSerials _totalabSerials = new SamplerSerials();


        
    }
}
