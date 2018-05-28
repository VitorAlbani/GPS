using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GPS_API.Models;
using GPS_API.Data;
using Newtonsoft.Json;

namespace GPS_API.Controllers
{
    [RoutePrefix("api/GPS")]
    public class GPSController : ApiController
    {
        [Route("AddFriendLocation")]
        public object AddFriend(Friend friend)
        {
            string error = "";
            string returnMsg = "";
            if (string.IsNullOrEmpty(friend.name))
                error = "Nome Precisa estar preenchido.";

            if (string.IsNullOrEmpty(friend.locationx.ToString()))
                error = "Localização X precisa estar preenchida.";

            if (string.IsNullOrEmpty(friend.locationy.ToString()))
                error = "Localização Y precisa estar preenchida.";

            if (!string.IsNullOrEmpty(error))
                return JsonConvert.SerializeObject(error);

            Friend _friend = new Friend
            {
                name = friend.name,
                locationx = friend.locationx,
                locationy = friend.locationy
            };

            if (InsertFriend(_friend))
                returnMsg = "Inserido com sucesso";
            else
                returnMsg = "Erro ao inserir";

            return JsonConvert.SerializeObject(returnMsg);
        }

        [Route("GetFriends")]
        public object GetFriendList()
        {
            List<Friend> friends = GetFriends();

            return JsonConvert.SerializeObject(friends);
        }

        private List<Friend> GetFriends()
        {
            Connection cnn = Connection.GetConnection();
            List<Friend> friends = cnn.GetFriends();

            return friends;
        }

        private bool InsertFriend(Friend friend)
        {
            Connection cnn = Connection.GetConnection();


            return cnn.InsertFriend(friend);
        }
    }
}
