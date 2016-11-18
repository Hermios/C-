using StandardTools.ServiceLocator;
using System;
using System.Collections.Generic;
using System.Linq;
namespace GlobalERP.Helpers
{
    public class ParametersHandler<T>:IService where T:struct,IConvertible
    {
        const string PARAM_FILE= "paramterers.ini";
        private Dictionary<T, string> _params;
        public ParametersHandler()
        {
            _params = new Dictionary<T, string>();
            foreach(string line in System.IO.File.ReadAllLines(PARAM_FILE))
            {
                if (!line.Contains("="))
                    //ignore chapters, for now
                    continue;

                //load parameter
                string[] paramData = line.Split('=');
                _params.Add((T)Enum.Parse(typeof(T), paramData[0], true),paramData[0]);
            }
        }

        public string getString(T key)
        {
            return _params[key];
        }

        public bool getBool(T key)
        {
            bool result = false;
            if (!bool.TryParse(getString(key), out result))
                throw new FormatException();
            return result;
        }

        public int getInt(T key)
        {
            int result = -1;
            if (!int.TryParse(getString(key), out result))
                throw new FormatException();
            return result;
        }

        public void initService(object[] args)
        {
            
        }
    }

   
}
