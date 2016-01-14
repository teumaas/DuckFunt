using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Xml.Serialization;
using Microsoft.Xna.Framework.Storage;


namespace MenuMaking
{
    class HighScores
    {
        public static string path;
        public static SaveData data;

        public HighScores(string filename)
        {
            data = new SaveData();
            path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, filename);
        }
        public static void Save(SaveData save)
        {
          //  string fullpath = Path.Combine(@"Content\Samples")
          //  path = TitleContainer.OpenStream(@"Content\Samples").ToString();
            
            FileStream stream = File.Open(path, FileMode.OpenOrCreate);
  //          FileStream = File.Open(path, FileMode.OpenOrCreate, FileAccess.Read);
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(SaveData));
                serializer.Serialize(stream, save);

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                stream.Close();
            }
        }

        public static SaveData LoadHighScores(string filename)
        {
            SaveData data;
            FileStream stream = File.Open(path, FileMode.OpenOrCreate, FileAccess.Read);
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof (SaveData));
                data = (SaveData) serializer.Deserialize(stream);
            }
            finally
            {
                stream.Close();
            }
            return (data);

        }
    }
}
