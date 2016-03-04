using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Superheroes.Web.ViewModels
{
    public class ContactViewModel
    {
        public string DevName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Phone { get; set; }
        public string EMail { get; set; }

        public ContactViewModel()
        {
            this.DevName = "Проскурин Иван Александрович";
            this.Address1 = "г. Архангельск, Россия";
            this.Address2 = "ул. Вологодская 25, кв. 65";
            this.Phone = "+7-999-250-9459";
            this.EMail = "ivan.proskurin@gmail.com";
        }
    }
}