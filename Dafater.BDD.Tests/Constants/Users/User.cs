using BLL.Users;
using BLL.Utilities;
using System;
using System.Linq;

namespace BLL.Data
{
    public class User
    {
        public static UserInfo GetUserCredentioalByName(string user)
        {
            return CsvHelper.ReadCsvFile("Users.csv")
                                           .Skip(1)
                                           .Select(row => ReadUsers(row))
                                           .ToList().
                                           FirstOrDefault(UserCredentioal => UserCredentioal.UserName == user);
        }

        private static UserInfo ReadUsers(String csvRow)
        {
            string[] value = csvRow.Split(',');
            UserInfo user = new UserInfo
            {
                UserName = value[0],
                Id = value[1],
                Password = value[2]
            };
            return user;
        }
    }
}
