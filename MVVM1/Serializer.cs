using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using MVVM1.Model;

namespace MVVM1
{
    class Serializer
    {
        public static void Serialize(UserList userList)
        {
            var serializer = new XmlSerializer(userList.GetType());
            using (var writer = XmlWriter.Create("userslist.xml"))
            {
                serializer.Serialize(writer, userList);
            }
        }
        public static UserList Deserialize()
        {
            var serializer = new XmlSerializer(typeof(UserList));
            using (var reader = XmlReader.Create("userslist.xml"))
            {
                var userList = (UserList)serializer.Deserialize(reader);
                return userList;
            }
        }
    }
}
