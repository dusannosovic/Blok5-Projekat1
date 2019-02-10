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
            try
            {
                using (var reader = XmlReader.Create("userslist.xml"))
                {
                    var userList = (UserList)serializer.Deserialize(reader);
                    return userList;
                }
            }
            catch
            {
                return new UserList();
            }
        }
        public static void SerializeUser(Users user)
        {
           var serializer = new XmlSerializer(user.GetType());
            using (var writer = XmlWriter.Create("user.xml"))
            {
                serializer.Serialize(writer, user);
            }
        }
        public static Users DeserializeUser()
        {
            var serializer = new XmlSerializer(typeof(Users));
            try
            {
                using (var reader = XmlReader.Create("user.xml"))
                {
                    var user = (Users)serializer.Deserialize(reader);
                    return user;
                }
            }
            catch
            {
                return null;
            }
        }
    }
}
