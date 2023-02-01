using System;
using System.Collections.Generic;
using System.Text;
using Firebase.Database;

namespace Dragonballheroes.Conexiones
{
    public class Cconexion
    {
        public static FirebaseClient firebase = new FirebaseClient("https://dragonball-ae310-default-rtdb.firebaseio.com");

    }
}
