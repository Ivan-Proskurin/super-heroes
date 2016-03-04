using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Superheroes.Web.ViewModels
{
    public class AppInfoViewModel
    {
        public string ApplicationTitle { get; set; }
        public string ApplicationDetails { get; set; }
        public string AuthorNickname { get; set; }

        public AppInfoViewModel()
        {
            this.ApplicationTitle = "Супергерои";
            this.ApplicationDetails = "Библиотека супергероев с возможностью добавлять новых героев, редактировать их суперспособности и прочее.";
            this.AuthorNickname = "crusader";
        }
    }
}