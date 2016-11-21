using StandardTools.ServiceLocator;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GlobalERP.Helpers
{
    public class ParametersHandler<T>:IService where T:struct,IConvertible
    {
        const string PARAM_FILE_EXT= ".ini";
        private Dictionary<T, string> _params;
        public ParametersHandler()
        {
            string paramFile = typeof(T).Name + PARAM_FILE_EXT;
            _params = new Dictionary<T, string>();

            if(!File.Exists(paramFile))
            {
                using (StreamWriter w = File.CreateText(paramFile))
                {
                    foreach (var key in Enum.GetValues(typeof(T)).OfType<T>())
                        w.WriteLine(key.ToString() + "=");
                }
            }
            foreach (string line in File.ReadAllLines(paramFile))
            {
                if (!line.Contains("="))
                    //ignore chapters, for now
                    continue;

                //load parameter
                string[] paramData = line.Split('=');
                _params.Add((T)Enum.Parse(typeof(T), paramData[0], true),paramData[1]);
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

        public void initService(IServiceLocator serviceLocator, params object[] args)
        {
        }
    }

   
}
