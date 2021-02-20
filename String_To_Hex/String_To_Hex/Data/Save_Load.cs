using Newtonsoft.Json;
using System;
using System.IO;
using System.Text;

namespace String_To_Hex.Data
{
    //found the ToHexString() FromHexString() 
    //here: https://stackoverflow.com/questions/16999604/convert-string-to-hex-string-in-c-sharp
    //poster: franckspike

    public class Save_Load<T>
    {
        private string savefile;

        private bool useHex;

        /// <summary>
        /// Creates a new instance of Save_Load
        /// </summary>
        /// <param name="savefile">the full path to the save file, include filename and extension</param>
        /// <param name="useHex">true = save as a hex string | false = save as a .json string</param>
        public Save_Load(string savefile, bool useHex)
        {
            this.savefile = savefile;
            this.useHex = useHex;
        }


        #region Save

        /// <summary>
        /// Saves to a file
        /// </summary>
        /// <param name="_gameData">The class that you want to save</param>
        public void Save(T _gameData)
        {
            //to save
            //--ToJson -> ToHex -> Push

            if (useHex)
            {
                Push(ToHexString(ToJson(_gameData)));
            }
            else
            {
                Push(ToJson(_gameData));
            }

        }

        private string ToJson(T _data)
        {
            return JsonConvert.SerializeObject(_data);
        }

        private string ToHexString(string str)
        {
            var sb = new StringBuilder();

            var bytes = Encoding.Unicode.GetBytes(str);
            foreach (var t in bytes)
            {
                sb.Append(t.ToString("X2"));
            }

            return sb.ToString(); // returns: "48656C6C6F20776F726C64" for "Hello world"
        }

        private void Push(string _data)
        {
            using (StreamWriter sw = new StreamWriter(savefile))
            {
                sw.Write(_data);
                sw.Close();
            }
        }

        #endregion

        #region Load

        /// <summary>
        /// Load the save file 
        /// </summary>
        /// <returns>returns save file as type T</returns>
        public T Load()
        {
            //to load
            //--Pull -> FromHex -> FromJson

            if (useHex)
            {
                return FromJson(FromHexString(Pull()));
            }
            else
            {
                return FromJson(Pull());
            }

        }


        private string Pull()
        {
            string _data = "";

            using (StreamReader sr = new StreamReader(savefile))
            {
                _data = sr.ReadToEnd();
                sr.Close();
            }

            return _data;
        }

        private string FromHexString(string hexString)
        {
            var bytes = new byte[hexString.Length / 2];
            for (var i = 0; i < bytes.Length; i++)
            {
                bytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
            }

            return Encoding.Unicode.GetString(bytes); // returns: "Hello world" for "48656C6C6F20776F726C64"
        }

        private T FromJson(string _data)
        {
            return JsonConvert.DeserializeObject<T>(_data);
        }

        #endregion


    }
}
