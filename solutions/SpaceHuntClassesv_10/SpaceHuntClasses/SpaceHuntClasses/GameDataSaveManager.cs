using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace SpaceHuntClasses
{
    public class GameDataSaveManager
    {
        private string path;
        private string fileName;

        public GameDataSaveManager(string fileName)
        {
            path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);
        }

        public void Save(List<GameData> save)
        {
            FileStream stream = File.Open(path, FileMode.OpenOrCreate);

            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<GameData>));
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



        public List<GameData> LoadGameDatas()
        {
            List<GameData> data = new List<GameData>();
            FileStream stream = File.Open(path, FileMode.OpenOrCreate, FileAccess.Read);
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<GameData>));
                data = (List<GameData>)serializer.Deserialize(stream);
            }
            catch (InvalidOperationException)
            {
                //stream.Close();
                //List<GameData> temp = new List<GameData>(1);
                //GameData temp2 = new GameData();
                //temp2.kills = 0;
                //temp2.rounds = 10;
                ////temp2.shotsFired = 0;
                //temp2.playerName = "NON";
                //temp.Add(temp2);
                //Save(temp);
                //data = temp;
                //;
            }
            finally
            {
                stream.Close();
            }

            return (data);

        }
    }
}
