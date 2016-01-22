using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Xml.Serialization;
using Microsoft.Xna.Framework.Storage;
using Saveme = MenuMaking.SaveData;


namespace MenuMaking
{
    class HighScoresSaveManager
    {
        public struct HighScoreData
        {
            public string playerName;
            public decimal kills;
            public decimal shotsFired;
            public decimal rounds;
            public TimeSpan time;
        }
        public static string path;
        public static SaveData data;

        public HighScoresSaveManager(string filename)
        {
            data = new SaveData();
            path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, filename);
        } 
        public void Save(List<Saveme> save)
        {
          //  string fullpath = Path.Combine(@"Content\Samples") 
          //  path = TitleContainer.OpenStream(@"Content\Samples").ToString();
            
            FileStream stream = File.Open(path, FileMode.OpenOrCreate);
  //          FileStream = File.Open(path, FileMode.OpenOrCreate, FileAccess.Read);
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Saveme>));
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

        public List<Saveme> LoadHighScores(string filename)
        {
            List<Saveme> data;
            FileStream stream = File.Open(path, FileMode.OpenOrCreate, FileAccess.Read);
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof (List<Saveme>));
                data = (List<Saveme>) serializer.Deserialize(stream);
            }
            finally
            {
                stream.Close();
            }
            return (data);

        }
    }
}
