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
        
        public static string path;
        public static SaveData data;
        private string fileName;

        public HighScoresSaveManager(string filename)
        {
            fileName = filename;
            data = new SaveData();
            path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, filename);
        } 
        public void Save(List<Saveme> save)
        {
          //  string fullpath = Path.Combine(@"Content\Samples") 
          //  path = TitleContainer.OpenStream(@"Content\Samples").ToString();
            
            FileStream stream = File.Open(path, FileMode.OpenOrCreate);
  //         FileStream = File.Open(path, FileMode.OpenOrCreate, FileAccess.Read);
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

        public List<Saveme> LoadHighScores()
        {
            List<Saveme> data;
            FileStream stream = File.Open(path, FileMode.OpenOrCreate, FileAccess.Read);
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof (List<Saveme>));
                data = (List<Saveme>) serializer.Deserialize(stream);
            }
            catch (InvalidOperationException)
            {
                stream.Close();
                List<Saveme> temp = new List<SaveData>(1);
                Saveme temp2 = new Saveme();
                temp2.kills = 0;
                temp2.rounds = 0;
                temp2.shotsFired = 0;
                temp2.playerName = "NON";
                temp.Add(temp2);
                Save(temp);
                data = temp;
;            }
            finally
            {
                stream.Close();
            }
            
            return (data);

        }
    }
}
